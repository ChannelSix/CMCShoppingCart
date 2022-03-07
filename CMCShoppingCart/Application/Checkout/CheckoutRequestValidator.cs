using CMCShoppingCart.Common;
using CMCShoppingCart.Domain.Products;

namespace CMCShoppingCart.Application.Checkout
{
    public interface ICheckoutRequestValidator
    {
        Task<List<string>> GetValidationMessages(CheckoutRequest request);
    }

    public class CheckoutRequestValidator : ICheckoutRequestValidator
    {
        private readonly IProductRepository _productRepository;

        public CheckoutRequestValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<string>> GetValidationMessages(CheckoutRequest request)
        {
            var result = new List<string>();

            // all product ids must exist
            var productIds = request.LineItems.Select(li => li.ProductId).ToArray();
            var allExist = await _productRepository.AllIdsExist(productIds);
            if (!allExist) result.Add(ValidationMessages.InvalidProductId);

            return result;
        }
    }
}
