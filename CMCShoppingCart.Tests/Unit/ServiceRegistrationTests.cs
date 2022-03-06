using CMCShoppingCart.Domain.Products;
using Microsoft.Extensions.DependencyInjection;

namespace CMCShoppingCart.Tests.Unit;

public class ServiceRegistrationTests
{
    [Fact]
    public void Register_IncludesSingleImplmentationTypes()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        services.RegisterServices();

        // assert
        var serviceDescriptor = services.Single(s => s.ServiceType == typeof(IProductRepository));
        serviceDescriptor.Lifetime.Should().Be(ServiceLifetime.Scoped);
        serviceDescriptor.ImplementationType.Should().Be(typeof(ProductRepository));
    }
}
