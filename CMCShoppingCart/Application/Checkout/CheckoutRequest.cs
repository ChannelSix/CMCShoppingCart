using CMCShoppingCart.Common;
using System.ComponentModel.DataAnnotations;

namespace CMCShoppingCart.Application.Checkout;

public class CheckoutRequest
{
    [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.CheckoutTotalLineItemsExist))]
    [MinLength(1, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.CheckoutTotalLineItemsExist))]
    public List<CheckOutRequestLineItem> LineItems { get; set; } = new();
}

public class  CheckOutRequestLineItem
{ 
    [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.InvalidProductId))]
    public Guid ProductId { get; set; }
    [Range(1, 1000, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.QuantityRange))]
    public int Quantity { get; set; }
}