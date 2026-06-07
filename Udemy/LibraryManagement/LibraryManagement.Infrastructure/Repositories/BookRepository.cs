using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context):base(context)
        {

        }

        public async Task<IEnumerable<Book>> GetBooksWithAllDetailsAsync()
        {
            return await _context.Books
                .Include(b=>b.Category)
                .Include(b=>b.Author)
                .Where(m => !m.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetCatalogBooksAsync()
        {
            return await _context.Books
                .Include(b=>b.Loans)
                .ToListAsync();            
        }
    }
}
