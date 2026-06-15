using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; protected set; }
    }

    public interface IMustHaveTenant
    {
        int TenantId { get; }
        bool IsDeleted { get; }
    }
}
