using ECommerceSystem.Application.Interfaces;
using ECommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task AddEntityAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
