using AutoMapper;
using CMCShoppingCart.Domain.Products;

namespace CMCShoppingCart.Application.Products;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAll();
}

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetAll();

        var result = products
            .Select(_mapper.Map<ProductDto>);

        return result;
    }
}
