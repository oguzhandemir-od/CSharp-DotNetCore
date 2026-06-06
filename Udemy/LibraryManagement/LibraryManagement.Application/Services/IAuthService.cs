using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Services
{
    public interface IAuthService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateToken(int id, string email, string role);
    }
}
