using MovieManagementProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieManagementProject.Controllers
{
    public class HomeController : Controller
    {
        private MovieDbContext db = new MovieDbContext();
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();

            
            //var popularMovies = db.Movies
            //                             .Where(m => m.IsPopular)  
            //                             .OrderByDescending(m => m.Rating) 
            //                             .Take(5)  
            //                             .ToList();

            
            ViewBag.Categories = categories;
            //ViewBag.PopularMovies = popularMovies;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserIndex(int page = 1)
        {
            int pageSize = 6; // Her sayfada gösterilecek film sayısı
            var totalMovies = db.Movies.Count(); // Toplam film sayısını al
            var totalPages = (int)Math.Ceiling((double)totalMovies / pageSize); // Toplam sayfa sayısı hesapla

            var movies = db.Movies
                .OrderBy(m => m.Title) // Filmleri sıralayalım
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList(); // O sayfada yer alan filmleri al

            ViewBag.Movies = movies;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View();
        }

        public ActionResult UserDetails(int id)
        {
            var movie = db.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();  // Eğer film bulunmazsa 404 döndür
            }

            return View(movie);  // Detaylar view'ına film verisini gönder
        }

        public ActionResult ViewByCategory(int id)
        {
            var category = db.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            var moviesInCategory = db.Movies
                                            .Where(m => m.CategoryId == id)
                                            .ToList();

            ViewBag.CategoryName = category.Name;
            return View(moviesInCategory);
        }
    }
}