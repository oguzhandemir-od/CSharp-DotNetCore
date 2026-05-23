using efp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace efp.VeriErisimi
{
    public class SatisContext : DbContext
    {
        public SatisContext() : base("SatisVeritabani") 
        {
            Database.SetInitializer(new ilksatisInitializer());
        }
        public DbSet<Urun> Urunler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}