using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
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

        public async Task<bool> PaySinglePenaltyAsync(int penaltyId)
        {
            // Veritabanından sadece o spesifik cezayı buluyoruz
            var penalty = await _context.Penalties.FirstOrDefaultAsync(p => p.Id == penaltyId && !p.IsPaid);

            if (penalty == null)
                return false;

            // Sadece bu cezayı ödenmiş olarak işaretliyoruz
            penalty.IsPaid = true;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> PayAllPenaltiesAsync(int memberId)
        {
            var unpaidPenalties = await _context.Penalties
                .Where(p => p.MemberId == memberId && !p.IsPaid)
                .ToListAsync();

            if (!unpaidPenalties.Any())
                return false;

            foreach (var penalty in unpaidPenalties)
            {
                penalty.IsPaid = true;
            }

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
