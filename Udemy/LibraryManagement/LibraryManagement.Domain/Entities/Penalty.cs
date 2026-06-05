using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Domain.Entities
{
    public class Penalty:BaseEntity
    {

        public int LoanId { get; set; }
        public Loan Loan { get; set; }

        
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public decimal Amount { get; set; } 
        public bool IsPaid { get; set; } = false; 
        public DateTime PenaltyDate { get; set; } = DateTime.UtcNow;
    }
}
