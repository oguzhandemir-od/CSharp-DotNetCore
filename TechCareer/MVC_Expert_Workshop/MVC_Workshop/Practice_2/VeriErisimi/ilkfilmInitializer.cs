using Practice_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practice_2.VeriErisimi
{
    public class ilkfilmInitializer:DropCreateDatabaseIfModelChanges<FilmContext>
    {
        protected override void Seed(FilmContext context)
        {
            List<Film> filmler = new List<Film>
            {
                new Film{Ad="Hızlı ve Öfkeli", Aciklama="Hızlı ve Öfkeli",Tur="Aksiyon",Puan=8},
                new Film{Ad="Kaptan Amerika",Aciklama="Kaptan Amerika",Tur="Bilim Kurgu",Puan=8},
                new Film{Ad="Batman",Aciklama="Batman",Tur="Aksiyon",Puan=9}
            };
            filmler.ForEach(film => context.Filmler.Add(film));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}