using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Member>> GetMembersWithAllDetailsAsync()
        {
            return await _context.Members
                .Include(m => m.Loans)
                    .ThenInclude(l => l.Book)
                .Include(m => m.Penalties)
                .Where(m => !m.IsDeleted)
                .ToListAsync();
        }
    }
}
