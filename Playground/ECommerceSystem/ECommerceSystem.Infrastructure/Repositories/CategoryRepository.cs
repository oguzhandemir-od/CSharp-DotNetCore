using ECommerceSystem.Application.Interfaces;
using ECommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task AddEntityAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
