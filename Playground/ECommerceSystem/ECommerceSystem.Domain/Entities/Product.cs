using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
