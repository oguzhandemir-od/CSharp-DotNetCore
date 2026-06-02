using ECommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Application.Interfaces
{
    public interface IAuthService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateToken(User user);
    }
}
