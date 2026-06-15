using GlobalPublishing.Application.Interfaces;
using GlobalPublishing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public IQueryable<T> GetAll(bool trackChanges = false)
        {
            return !trackChanges
                ? _dbSet.AsNoTracking()
                : _dbSet;
        }

        public IQueryable<T> GetByfilter(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            var query = !trackChanges ? _dbSet.AsNoTracking() : _dbSet;
            return query.Where(expression);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
