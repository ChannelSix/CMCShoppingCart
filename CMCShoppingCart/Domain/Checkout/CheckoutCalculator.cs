using CMCShoppingCart.Domain.Products;

namespace CMCShoppingCart.Domain.Checkout;

public interface ICheckoutCalculator
{
    decimal CalculateShippingTotal(decimal productTotal);
    Task<IDictionary<Product, decimal>> GetProductLineItemTotals(IDictionary<Guid, int> productQuantities);
}

public class CheckoutCalculator : ICheckoutCalculator
{
    private readonly IProductRepository _productRepository;

    public CheckoutCalculator(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IDictionary<Product, decimal>> GetProductLineItemTotals(IDictionary<Guid, int> productQuantities)
    {
        var result = new Dictionary<Product, decimal>();
        foreach (var lineItem in productQuantities)
        {
            var product = await _productRepository.GetById(lineItem.Key);
            var total = product.UnitPrice * lineItem.Value;
            result.Add(product, total);
        }
        return result;
    }

    public decimal CalculateShippingTotal(decimal productTotal)
        => productTotal <= 50 ? 10 : 20;
}
