namespace CMCShoppingCart.Application.Checkout;

public class CheckoutTotalDto
{
    public List<CheckoutTotalLineItemDto> LineItems { get; set; } = new();
    public decimal Shipping { get; set; }
    public decimal Total { get; set; }
}

public class CheckoutTotalLineItemDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}