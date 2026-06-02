using ECommerceSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        public Task AddEntityAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
