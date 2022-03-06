namespace CMCShoppingCart.Domain.Products;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }

    /*
    ** If this was a data entity, typically we would have other properties here such as a ConcurrencyToken,
    ** maybe LastUpdatedTime and LastUpdatedBy etc.
    */
}
