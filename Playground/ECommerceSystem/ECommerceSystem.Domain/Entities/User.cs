using ECommerceSystem.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public RoleEnum Role { get; set; }
    }
}
