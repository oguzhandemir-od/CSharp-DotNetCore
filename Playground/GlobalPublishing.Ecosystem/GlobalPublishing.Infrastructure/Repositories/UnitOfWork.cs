using GlobalPublishing.Application.Interfaces;
using GlobalPublishing.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {  _context = context; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
