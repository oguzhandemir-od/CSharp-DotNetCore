using ECommerceSystem.Application.Interfaces;
using ECommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task AddEntityAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
