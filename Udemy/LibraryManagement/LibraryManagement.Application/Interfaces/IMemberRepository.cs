using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Interfaces
{
    public interface IMemberRepository:IGenericRepository<Member>
    {
        Task<IEnumerable<Member>> GetMembersWithAllDetailsAsync();
        Task<bool> PaySinglePenaltyAsync(int penaltyId);
        Task<bool> PayAllPenaltiesAsync(int id);

    }
}
