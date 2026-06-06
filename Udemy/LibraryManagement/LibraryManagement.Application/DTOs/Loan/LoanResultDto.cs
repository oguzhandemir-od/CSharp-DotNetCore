using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs.Loan
{
    public class LoanResultDto
    {
        public string MemberFullName { get; set; }
        public string BookName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
