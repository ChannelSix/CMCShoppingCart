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
    public Task<IActionResult> GetTotals(CheckoutTotalRequest request)
        => _checkoutService.GetCheckoutTotal(request).ToActionResult();       
}
