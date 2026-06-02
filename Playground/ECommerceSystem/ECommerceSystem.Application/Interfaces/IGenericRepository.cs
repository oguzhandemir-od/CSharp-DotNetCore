using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddEntityAsync(T entity);
        Task UpdateEntityAsync(T entity);
        Task DeleteEntityAsync(int id);
    }
}
