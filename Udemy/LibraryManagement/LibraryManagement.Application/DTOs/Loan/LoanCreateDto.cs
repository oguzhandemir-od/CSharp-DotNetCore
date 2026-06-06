using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs.Loan
{
    public class LoanCreateDto
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public int StaffId { get; set; }
    }
}
