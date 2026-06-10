using ProductStockManagement.Entities;

namespace ProductStockManagement.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(int id);
        void Update(Product product);
    }
}
