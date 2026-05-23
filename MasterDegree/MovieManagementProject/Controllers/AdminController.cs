using MovieManagementProject.DAL;
using MovieManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieManagementProject.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private MovieDbContext db=new MovieDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            var movieCount = db.Movies.Count();
            var categoryCount = db.Categories.Count();
            //var userCount = db.Users.Count();


            var latestMovies = db.Movies.OrderByDescending(p => p.Id).Take(5).ToList();

            // ViewData ile özet verileri View'a gönder
            ViewData["MovieCount"] = movieCount;
            ViewData["CategoryCount"] = categoryCount;
            //ViewData["UserCount"] = userCount;
            ViewData["LatestMovies"] = latestMovies;
            return View();
            
            
        }
    }
}