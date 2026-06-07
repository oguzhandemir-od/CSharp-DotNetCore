using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs.Member
{
    public class MemberPenaltyDto
    {
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PenaltyDate { get; set; }
    }
}
