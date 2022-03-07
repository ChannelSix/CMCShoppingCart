using CMCShoppingCart.Application.Checkout;

namespace CMCShoppingCart.Tests.Unit.Application.Checkout;

public class CheckoutServiceTests : UnitTestBase<CheckoutService>
{
    [Fact]
    public void CheckoutComplete_ReturnsIncrementedOrderNo()
    {
        Subject.CheckoutComplete(new CheckoutRequest()).OrderNo.Should().Be("000001");
        Subject.CheckoutComplete(new CheckoutRequest()).OrderNo.Should().Be("000002");
    }
}
