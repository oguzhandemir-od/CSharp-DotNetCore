using GlobalPublishing.Application.Interfaces;
using GlobalPublishing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Infrastructure.Context
{
    public class AppDbContext:DbContext
    {
        private readonly int _currentTenantId;
        private readonly ITenantService _tenantService;
        public AppDbContext(DbContextOptions<AppDbContext> options,ITenantService tenantService) : base(options) 
        {
            _currentTenantId = tenantService.GetTenantId();
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookTranslation> BookTranslations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(builder =>
            {
                builder.ToTable(t => t.HasCheckConstraint("CK_Book_PageCount", "[PageCount]>0"));

                builder.HasIndex(b => new { b.TenantId, b.IsDeleted });

                builder.HasQueryFilter(b => !b.IsDeleted);
            });

            modelBuilder.Entity<BookTranslation>(builder =>
            {
                builder.HasKey(bt => new { bt.BookId, bt.LanguageId });
            });

            modelBuilder.Entity<Author>(builder =>
            {
                builder.HasQueryFilter(a => !a.IsDeleted && a.TenantId == _currentTenantId);
            });


        }
    }
}
