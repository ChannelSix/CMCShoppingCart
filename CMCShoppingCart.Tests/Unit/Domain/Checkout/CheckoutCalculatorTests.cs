using CMCShoppingCart.Domain.Checkout;
using CMCShoppingCart.Domain.Products;

namespace CMCShoppingCart.Tests.Unit.Domain.Checkout;

public class CheckoutCalculatorTests : UnitTestBase<CheckoutCalculator>
{
    [Fact]
    public async Task GetProductLineItemTotals_ReturnsCorrectValues()
    {
        // arrange
        var p1 = new Product { Id = Guid.NewGuid(), Name = "P1", UnitPrice = 5.25m };
        var p2 = new Product { Id = Guid.NewGuid(), Name = "P2", UnitPrice = 5.5m };
        var mockRepository = GetMock<IProductRepository>();
        mockRepository.GetById(p1.Id).Returns(p1);
        mockRepository.GetById(p2.Id).Returns(p2);
        var productQuantities = new Dictionary<Guid, int>
        {
            { p1.Id, 2 },
            { p2.Id, 3 },
        };

        // act
        var lineItems = await Subject.GetProductLineItemTotals(productQuantities);

        // assert
        lineItems.Should().HaveCount(2);
        lineItems[p1].Should().Be(10.5m);
        lineItems[p2].Should().Be(16.5m);
    }

    [Theory]
    [InlineData(10, 10)]
    [InlineData(50, 10)]
    [InlineData(55, 20)]
    public void CalculateShippingTotal_ReturnsCorrectValues(decimal productTotal, decimal expected)
    {
        Subject.CalculateShippingTotal(productTotal).Should().Be(expected);
    }
}
