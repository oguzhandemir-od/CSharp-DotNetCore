using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs.Member
{
    public class MemberResultDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public ICollection<MemberLoanDto> Loans { get; set; } = new List<MemberLoanDto>();
        public ICollection<MemberPenaltyDto> Penalties { get; set; } = new List<MemberPenaltyDto>();
    }
}
