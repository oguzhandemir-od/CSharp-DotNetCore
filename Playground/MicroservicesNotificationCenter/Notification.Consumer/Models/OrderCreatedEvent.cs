using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Consumer.Models
{
    public class OrderCreatedEvent
    {
        public Guid OrderId { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
