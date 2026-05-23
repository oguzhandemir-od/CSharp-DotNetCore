using Microsoft.AspNet.Identity;
using MovieManagementProject.DAL;
using MovieManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieManagementProject.Controllers
{ }
//    public class UserMoviesController : Controller
//    {
//        private MovieDbContext db;

//        // GET: UserMovies
//        public ActionResult Index()
//        {
//            return View();
//        }
             
//        // İzlediklerim
//        public ActionResult Watched()
//        {
//            var userId = User.Identity.GetUserId();
//            var watchedMovies = db.UserMovies
//                .Where(um => um.UserId == userId && um.ListType == "Watched")
//                .Select(um => um.Movie)
//                .ToList();

//            ViewBag.Title = "İzlediklerim";
//            return View(watchedMovies);
//        }

//        // İzleme Listem
//        public ActionResult Watchlist()
//        {
//            var userId = User.Identity.GetUserId();
//            var watchlistMovies = db.UserMovies
//                .Where(um => um.UserId == userId && um.ListType == "Watchlist")
//                .Select(um => um.Movie)
//                .ToList();

//            ViewBag.Title = "İzleme Listem";
//            return View(watchlistMovies);
//        }

//        // Favorilerim
//        public ActionResult Favorites()
//        {
//            var userId = User.Identity.GetUserId();
//            var favoriteMovies = db.UserMovies
//                .Where(um => um.UserId == userId && um.ListType == "Favorites")
//                .Select(um => um.Movie)
//                .ToList();

//            ViewBag.Title = "Favorilerim";
//            return View(favoriteMovies);
//        }

//        // Listeden Film Kaldır
//        [HttpPost]
//        public ActionResult RemoveFromList(int movieId)
//        {
//            var userId = User.Identity.GetUserId();
//            var userMovie = db.UserMovies
//                .FirstOrDefault(um => um.UserId == userId && um.MovieId == movieId);

//            if (userMovie != null)
//            {
//                db.UserMovies.Remove(userMovie);
//                db.SaveChanges();
//            }

//            return RedirectToAction("Index");
//        }
//    //}
//}