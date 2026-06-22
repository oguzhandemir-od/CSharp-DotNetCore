using GlobalPublishing.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.Services
{
    public class TenantService:ITenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetTenantId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if(user?.Identity?.IsAuthenticated==true)
            {
                var tenantClaim = user.FindFirst("TenantId")?.Value;

                if (int.TryParse(tenantClaim, out int tenantId))
                    return tenantId;
            }

            return 0;
        }
    }
}
