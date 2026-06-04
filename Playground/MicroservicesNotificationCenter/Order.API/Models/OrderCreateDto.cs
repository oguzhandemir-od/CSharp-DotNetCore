namespace Order.API.Models
{
    public class OrderCreateDto
    {
        public string CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<string> ProductIds { get; set; }
    }
}
