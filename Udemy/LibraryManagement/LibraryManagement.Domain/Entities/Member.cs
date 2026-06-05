using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Domain.Entities
{
    public class Member:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
                
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<Penalty> Penalties { get; set; } = new List<Penalty>();

    }
}
