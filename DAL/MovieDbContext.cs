using MovieManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieManagementProject.DAL
{
    public class MovieDbContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<UserMovie> UserMovies { get; set; }

        
        public MovieDbContext() : base("MovieDatabase")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Movie>()
                .HasRequired(m => m.Category) 
                .WithMany(c => c.Movies)     
                .HasForeignKey(m => m.CategoryId); 
        }
    }
}