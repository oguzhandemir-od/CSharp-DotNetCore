using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LibraryManagement.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<IEnumerable<T>> GetEntitiesAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetEntityByIdAsync(int id);
        Task AddEntityAsync(T entity);
        Task UpdateEntityAsync(T entity);
        Task DeleteEntityAsync(int id);
    }
}
