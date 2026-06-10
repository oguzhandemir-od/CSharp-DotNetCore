using ProductStockManagement.Interfaces;

namespace ProductStockManagement.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void SellProduct(int productId, int quantity)
        {
            var product=_productRepository.GetById(productId);

            if (product == null)
                throw new Exception("Ürün bulunamadı.");

            product.DecreaseStock(quantity);

            _productRepository.Update(product);
        }
    }
}
