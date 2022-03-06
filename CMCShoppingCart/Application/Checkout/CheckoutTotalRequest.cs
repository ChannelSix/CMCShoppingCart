using CMCShoppingCart.Common;
using System.ComponentModel.DataAnnotations;

namespace CMCShoppingCart.Application.Checkout;

public class CheckoutTotalRequest
{
    [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.CheckoutTotalLineItemsExist))]
    [MinLength(1, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.CheckoutTotalLineItemsExist))]
    public List<CheckOutTotalLineItem> LineItems { get; set; } = new();
}

public class  CheckOutTotalLineItem
{ 
    [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.InvalidProductId))]
    public Guid ProductId { get; set; }
    [Range(1, 1000, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.QuantityRange))]
    public int Quantity { get; set; }
}