using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFirstRestApi.Models.Db;

public partial class RestApiDbContext : DbContext
{
    public RestApiDbContext()
    {
    }

    public RestApiDbContext(DbContextOptions<RestApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=RestApiDb;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC071436A88F");

            entity.Property(e => e.Color)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(150);
            entity.Property(e => e.Size)
                .HasMaxLength(5)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
