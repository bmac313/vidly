using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek"};
            var customers = new List<Customer>
            {
                new Customer { Name = "Alice D." },
                new Customer { Name = "Bob S." }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            string yearAbbr = year.ToString().Substring(2, 2);
            return Content(month + "/" + yearAbbr);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();

            if (movies == null)
            {
                return HttpNotFound();
            }
            

            var moviesViewModel = new MoviesViewModel
            {
                Movies = movies
            };

            return View(moviesViewModel);
        }

    }
}