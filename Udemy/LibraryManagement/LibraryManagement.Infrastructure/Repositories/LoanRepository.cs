using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(AppDbContext context) : base(context)
        {
        }
    }
}
