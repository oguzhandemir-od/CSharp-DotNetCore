using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Owin;
using MovieManagementProject.Models;
using Owin;
using System.Web.Hosting;

[assembly: OwinStartupAttribute(typeof(MovieManagementProject.Startup))]
namespace MovieManagementProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var dbContext = new ApplicationDbContext();
            dbContext.SeedRoles();
        }        
    }
}
