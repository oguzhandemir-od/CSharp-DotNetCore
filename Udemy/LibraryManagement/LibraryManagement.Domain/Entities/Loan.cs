using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Domain.Entities
{
    public class Loan:BaseEntity
    {

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public DateTime LoadDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate {  get; set; }
        public DateTime? ReturnDate {  get; set; }

        public bool IsReturned { get; set; } = false;

        public ICollection<Penalty> Penalties { get; set; } = new List<Penalty>();
    }
}
