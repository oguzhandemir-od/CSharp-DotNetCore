using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Penalty>()
                .HasOne(p => p.Member)
                .WithMany(m => m.Penalties)
                .HasForeignKey(p => p.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Member)
                .WithMany(m => m.Loans)
                .HasForeignKey(l => l.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
        .HasOne(l => l.Staff)
        .WithMany(s => s.ApprovedLoans)
        .HasForeignKey(l => l.StaffId)
        .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Staff> Staffs { get; set; }

    }
}
