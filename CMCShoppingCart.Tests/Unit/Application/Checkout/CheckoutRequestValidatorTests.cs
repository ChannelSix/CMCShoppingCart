using CMCShoppingCart.Application.Checkout;
using CMCShoppingCart.Common;
using CMCShoppingCart.Domain.Products;

namespace CMCShoppingCart.Tests.Unit.Application.Checkout
{
    public class CheckoutRequestValidatorTests : UnitTestBase<CheckoutRequestValidator>
    {
        [Fact]
        public async Task GetValidationMessages_HasMessagesOnMissingProductId()
        {
            // arrange
            GetMock<IProductRepository>().AllIdsExist(Arg.Any<Guid>()).Returns(false);
            var request = new CheckoutRequest
            {
                LineItems = new() { new CheckOutRequestLineItem() }
            };

            // act
            var validationMessages = await Subject.GetValidationMessages(request);

            // assert
            validationMessages.Should().HaveCount(1);
            validationMessages[0].Should().Be(ValidationMessages.InvalidProductId);
        }
    }
}
