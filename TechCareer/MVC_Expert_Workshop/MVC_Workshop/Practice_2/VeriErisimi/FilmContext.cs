using Practice_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Practice_2.VeriErisimi
{
    public class FilmContext:DbContext
    {
        public FilmContext() : base("FilmVeriTabani") 
        {
            Database.SetInitializer(new ilkfilmInitializer());
        }

        public DbSet<Film> Filmler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}