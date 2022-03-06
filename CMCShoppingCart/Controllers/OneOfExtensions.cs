using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace CMCShoppingCart.Controllers;

public static class OneOfExtensions
{
    public static async Task<IActionResult> ToActionResult<TPayload>(this Task<OneOf<List<string>, TPayload>> eitherErrorsOrPayloadTask)
    {
        var errorsOrPayload = await eitherErrorsOrPayloadTask;
        var result = errorsOrPayload.Match<IActionResult>
        (
            errors => new BadRequestObjectResult(errors),
            payload => new OkObjectResult(payload)
        );
        return result;
    }
}
