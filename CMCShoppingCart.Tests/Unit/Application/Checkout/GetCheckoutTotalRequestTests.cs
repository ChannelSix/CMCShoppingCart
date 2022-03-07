using CMCShoppingCart.Application.Checkout;
using CMCShoppingCart.Common;

namespace CMCShoppingCart.Tests.Unit.Application.Checkout;

public class GetCheckoutTotalRequestTests
{
    [Theory]
    [InlineData(true, nameof(ValidationMessages.CheckoutTotalLineItemsExist))]
    [InlineData(false, nameof(ValidationMessages.CheckoutTotalLineItemsExist))]
    public void PropertyValidation_ReturnsCorrectValidationMessages(bool setToNull, string messageKey)
    {
        // arrange
        var request = new CheckoutRequest 
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            LineItems = setToNull ? null : new()
#pragma warning restore CS8601 // Possible null reference assignment.
        };

        // act
        var (isValid, validationResults) = ObjectValidationHelper.Validate(request);

        // assert
        isValid.Should().BeFalse();
        validationResults.Should().HaveCount(1);
        var expectedMessage = ValidationMessages.ResourceManager.GetString(messageKey);
        validationResults[0].ErrorMessage.Should().Be(expectedMessage);
    }
}
