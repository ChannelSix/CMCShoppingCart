using AutoMapper;
using CMCShoppingCart.Application.Products;
using CMCShoppingCart.Domain.Products;

namespace CMCShoppingCart;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Product, ProductDto>();
    }
}

