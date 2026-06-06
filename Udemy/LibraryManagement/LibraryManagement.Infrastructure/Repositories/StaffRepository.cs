using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(AppDbContext context) : base(context)
        {
        }
    }
}
