using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity 
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddEntityAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(int id)
        {
            var entity = await GetEntityByIdAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync()
        {
            return await _context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(x => !x.IsDeleted);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task UpdateEntityAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
