using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
