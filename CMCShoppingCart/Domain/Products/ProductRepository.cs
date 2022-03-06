using CMCShoppingCart.Common;

namespace CMCShoppingCart.Domain.Products;

public interface IProductRepository
{
    Task<bool> AllIdsExist(params Guid[] ids);
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(Guid id);
}

public class ProductRepository : IProductRepository
{
    private static readonly Lazy<Dictionary<Guid, Product>> _productById = new(CreateMockProducts);

    public Task<IEnumerable<Product>> GetAll()
        => _productById.Value.Values.AsTask<IEnumerable<Product>>();

    public Task<bool> AllIdsExist(params Guid[] ids)
    {
        var someDontExist = ids.Any(id => !_productById.Value.ContainsKey(id));
        return (!someDontExist).AsTask();
    }

    public Task<Product> GetById(Guid id)
        => _productById.Value[id].AsTask();

    private static Dictionary<Guid, Product> CreateMockProducts()
    {
        var stuff = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Stuff",
            Description = "Beautiful, fantastic stuff.",
            UnitPrice = 6.99m
        };

        var things = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Things",
            Description = "How did we ever live without things?",
            UnitPrice = 8.72m
        };

        var widget = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Widget",
            Description = "What a wonderful widget!",
            UnitPrice = 5.49m
        };

        var result = new Dictionary<Guid, Product>()
        {
            { stuff.Id, stuff },
            { things.Id, things },
            { widget.Id, widget },
        };
        return result;
    }
}
