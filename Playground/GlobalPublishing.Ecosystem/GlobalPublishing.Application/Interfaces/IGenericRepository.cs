using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GlobalPublishing.Application.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        IQueryable<T> GetAll(bool trackChanges = false);

        IQueryable<T> GetByfilter(Expression<Func<T, bool>> expression, bool trackChanges = false);

        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
