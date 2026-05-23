using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using efp.Models;

namespace efp.VeriErisimi
{
    public class ilksatisInitializer : DropCreateDatabaseIfModelChanges<SatisContext>
    {
        protected override void Seed(SatisContext context)
        {
            List<Urun> urunler = new List<Urun>
            {
                new Urun{ Ad = "Notebook", Fiyat = 2000, StokSayisi= 300},
                new Urun{ Ad = "Tablet PC", Fiyat = 800, StokSayisi= 450},
                new Urun{ Ad = "Masaüstü PC", Fiyat = 1500,  StokSayisi= 150},
                new Urun{ Ad = "Ultrabook", Fiyat = 3000,  StokSayisi= 85},
                new Urun{ Ad = "Smartphone", Fiyat = 2000,  StokSayisi= 1000},
                new Urun{ Ad = "Tabphone", Fiyat = 3000,  StokSayisi= 50},
                new Urun{ Ad = "Led TV", Fiyat = 3500, StokSayisi= 50},
                new Urun{ Ad = "LCD TV", Fiyat = 1100,  StokSayisi= 30},
                new Urun{ Ad = "Plazma TV", Fiyat = 2250,  StokSayisi= 20}
            };
            urunler.ForEach(urun=>context.Urunler.Add(urun));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}