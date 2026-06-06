using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs.Member
{
    public class MemberPenaltyDto
    {
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PenaltyDate { get; set; }
    }
}
