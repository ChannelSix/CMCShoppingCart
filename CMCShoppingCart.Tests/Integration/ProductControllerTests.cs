using CMCShoppingCart.Common;
using CMCShoppingCart.Controllers;
using FluentAssertions;

namespace CMCShoppingCart.Tests.Integration;

public class ProductControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsExpectedProducts()
    {
        // arrange
        using var serviceProvider = IntegrationTestHelper.CreateScopedServiceProvider();
        var productController = serviceProvider.GetServiceOrThrow<ProductController>();

        // act
        var products = await productController.GetAll();

        // assert
        products.Should().HaveCount(3);
    }
}

