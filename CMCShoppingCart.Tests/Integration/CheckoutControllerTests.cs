using CMCShoppingCart.Application.Checkout;
using CMCShoppingCart.Common;
using CMCShoppingCart.Controllers;
using CMCShoppingCart.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace CMCShoppingCart.Tests.Integration;

public class CheckoutControllerTests
{
    [Fact]
    public async Task GetTotals_ReturnsCorrectValues()
    {
        // arrange
        using var serviceProvider = IntegrationTestHelper.CreateScopedServiceProvider();
        var productRepository = serviceProvider.GetServiceOrThrow<IProductRepository>();
        var allProducts = (await productRepository.GetAll()).ToList();
        var controller = serviceProvider.GetServiceOrThrow<CheckoutController>();
        var request = new CheckoutRequest
        {
            LineItems = new()
            {
                new CheckOutRequestLineItem { ProductId = allProducts[0].Id, Quantity = 2 },
                new CheckOutRequestLineItem { ProductId = allProducts[1].Id, Quantity = 3 },
            }
        };

        // act
        var objectResult = await controller.GetTotals(request);

        // assert
        objectResult.Should().BeOfType<OkObjectResult>();
        var totals = (CheckoutTotalDto)((OkObjectResult)objectResult).Value!;
        totals.Shipping.Should().Be(10);
        totals.Total.Should().Be(50.14m);
        totals.LineItems.Should().HaveCount(2);
        totals.LineItems[0].Should().BeEquivalentTo(new CheckoutTotalLineItemDto
        {
            ProductId = allProducts[0].Id,
            Name = "Stuff",
            Quantity = 2,
            UnitPrice = 6.99m,
            TotalPrice = 13.98m
        });
        totals.LineItems[1].Should().BeEquivalentTo(new CheckoutTotalLineItemDto
        {
            ProductId = allProducts[1].Id,
            Name = "Things",
            Quantity = 3,
            UnitPrice = 8.72m,
            TotalPrice = 26.16m
        });
    }
}
