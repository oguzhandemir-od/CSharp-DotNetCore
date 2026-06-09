using LibraryManagement.Application.DTOs.Member;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs.Loan
{
    public class LoanResultDto
    {
        // Personelin göreceği ödünç listesi
        public string MemberFullName { get; set; }
        public string BookName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }

        public string StaffName { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
