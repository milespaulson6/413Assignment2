using _413Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _413Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieRepository _repository;
        private MovieListContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MovieListContext cont)
        {
            _logger = logger;
            _repository = repository;
            context = cont;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieApplication()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieApplication(MovieResponse appResponse)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(appResponse);
                context.SaveChanges();
                return View("Confirmation", appResponse);
            }
            else
            {
                return View("MovieApplication");
            }
           
        }

        public IActionResult EditMovie(MovieResponse yeet)
        {
            //context.Movies.Where(x => x.MovieID == movieid);
            //_repository.Movies.Where(x => x.MovieID == yeet.MovieID);

            ViewBag.MovieID = yeet.MovieID;
            ViewBag.Category = yeet.Category;
            ViewBag.Title = yeet.Title;
            ViewBag.Year = yeet.Year;
            ViewBag.Director = yeet.Director;
            ViewBag.Rating = yeet.Rating;
            ViewBag.Edited = yeet.Edited;
            ViewBag.Lent = yeet.LentTo;
            ViewBag.Notes = yeet.Notes;

            
            return View();
        }

        public IActionResult SaveChange(MovieResponse mov)
        {
            //context.Movies.Where(t => t.MovieID == movieid).FirstOrDefault();
            
            context.Movies.Update(mov);
            context.SaveChanges();
            IQueryable<MovieResponse> query = context.Movies;
            return View("MovieList", query);

        }

        public IActionResult DeleteMovie(MovieResponse yeet)
        {
            context.Movies.Remove(yeet);
            context.SaveChanges();
            IQueryable<MovieResponse> query = context.Movies;
            return View("MovieList", query);
        }
        public IActionResult MovieList()
        {

            //

      
            return View(_repository.Movies.Where(movie => movie.Title != "Independence Day"));
            //
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
