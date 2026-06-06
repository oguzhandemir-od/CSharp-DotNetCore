using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs.Staff
{
    public class StaffRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
