using System.ComponentModel.DataAnnotations;

namespace CMCShoppingCart.Tests.Unit
{
    internal static class ObjectValidationHelper
    {
        public static (bool IsValid, List<ValidationResult> ValidationResults) Validate(object objectToValidate)
        {
            var context = new ValidationContext(objectToValidate);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(objectToValidate, context, validationResults, true);
            return (isValid, validationResults);
        }
    }
}
