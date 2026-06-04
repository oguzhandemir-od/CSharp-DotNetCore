namespace Order.API.Models
{
    public class OrderCreatedEvent
    {
        public Guid OrderId { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
