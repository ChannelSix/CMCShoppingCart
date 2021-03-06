using CMCShoppingCart.Domain.Checkout;
using CMCShoppingCart.Domain.Products;
using OneOf;

namespace CMCShoppingCart.Application.Checkout;

public interface ICheckoutService
{
    CheckoutCompleteDto CheckoutComplete(CheckoutRequest request);
    Task<OneOf<List<string>, CheckoutTotalDto>> GetCheckoutTotal(CheckoutRequest request);
}

public class CheckoutService : ICheckoutService
{
    static int _orderCount;

    private readonly ICheckoutCalculator _checkoutCalculator;
    private readonly ICheckoutRequestValidator _checkoutRequestValidator;

    public CheckoutService(
        ICheckoutCalculator checkoutCalculator,
        ICheckoutRequestValidator checkoutRequestValidator)
    {
        _checkoutCalculator = checkoutCalculator;
        _checkoutRequestValidator = checkoutRequestValidator;
    }

    public async Task<OneOf<List<string>, CheckoutTotalDto>> GetCheckoutTotal(CheckoutRequest request)
    {
        // validate request
        var validationResults = await _checkoutRequestValidator.GetValidationMessages(request);
        if (validationResults.Count > 0) return validationResults;

        // get line item totals
        var productIdTotals = GetProductIdTotals(request);
        var lineItemTotals = await _checkoutCalculator.GetProductLineItemTotals(productIdTotals);
        var lineItemDtos = MapToLineItems(productIdTotals, lineItemTotals);

        // calculate shipping and totals
        var subTotal = lineItemTotals.Values.Sum();
        var shipping = _checkoutCalculator.CalculateShippingTotal(subTotal);
        var total = subTotal + shipping;

        // result
        var result = new CheckoutTotalDto
        {
            LineItems = lineItemDtos,
            Shipping = shipping,
            Total = total
        };
        return result;
    }

    public CheckoutCompleteDto CheckoutComplete(CheckoutRequest request)
    {
        var orderNumber = Interlocked.Increment(ref _orderCount);
        var padded = $"00000{orderNumber}";
        var orderNumberString = padded.Substring(padded.Length - 6);
        var result = new CheckoutCompleteDto { OrderNo = orderNumberString };
        return result;
    }

    private IDictionary<Guid, int> GetProductIdTotals(CheckoutRequest request)
    {
        var result = request.LineItems
            .GroupBy(li => li.ProductId)
            .Select(g => new { ProductId = g.Key, Quantity = g.Sum(x => x.Quantity) })
            .ToDictionary(x => x.ProductId, x => x.Quantity);

        return result;
    }

    private List<CheckoutTotalLineItemDto> MapToLineItems(IDictionary<Guid, int> productIdTotals, IDictionary<Product, decimal> lineItemTotals)
    {
        var items = from kvp in lineItemTotals
                    let product = kvp.Key
                    select new CheckoutTotalLineItemDto
                    {
                        Name = product.Name,
                        ProductId = product.Id,
                        Quantity = productIdTotals[product.Id],
                        UnitPrice = product.UnitPrice,
                        TotalPrice = kvp.Value
                    };
        return items.ToList();
    }
}