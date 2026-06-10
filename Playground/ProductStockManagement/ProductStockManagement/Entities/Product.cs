namespace ProductStockManagement.Entities
{
    public class Product
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; private set; }

        public bool IsCriticalStock => StockQuantity < 5;

        public Product(int id, string name, int stockQuantity)
        {
            Id = id;
            Name = name;
            StockQuantity = stockQuantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Düşülecek stok miktarı 0'dan büyük olmalıdır.");

            if (StockQuantity < quantity)
                throw new InvalidOperationException("Yetersiz stok! İşlem gerçekleştirilemedi.");

            StockQuantity -= quantity;
        }
    }
}
