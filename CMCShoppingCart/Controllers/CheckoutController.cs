using CMCShoppingCart.Application.Checkout;
using Microsoft.AspNetCore.Mvc;

namespace CMCShoppingCart.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly ICheckoutService _checkoutService;

    public CheckoutController(ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    [HttpPost]
    public async Task<IActionResult> GetTotals(CheckoutTotalRequest request)
    {
        var eitherErrorsOrPayload = await _checkoutService.GetCheckoutTotal(request);
        var result = eitherErrorsOrPayload.Match
        (
            errorMessages => GetValidationProblem(errorMessages),
            payload => Ok(payload)
        );
        return result;
    }

    private IActionResult GetValidationProblem(List<string> errorMessages)
    {
        var errorDictionary = new Dictionary<string, string[]>
        {
            { string.Empty, errorMessages.ToArray() }
        };
        var validationDetails = new ValidationProblemDetails(errorDictionary);
        var result = ValidationProblem(validationDetails);
        return result;
    }
}
