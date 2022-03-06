using CMCShoppingCart.Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace CMCShoppingCart.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public Task<IEnumerable<ProductDto>> GetAll()
        => _productService.GetAll();
}
