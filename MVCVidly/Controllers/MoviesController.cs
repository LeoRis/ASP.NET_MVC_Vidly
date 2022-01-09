using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCVidly.Models;
using MVCVidly.ViewModels;

namespace MVCVidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

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
            var movie = new Movie() { Name = "Name!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // Parameter directly embeded into the URL
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
            //if (!pageIndex.HasValue)
            //{
            //    pageIndex = 1;
            //}

            //if (String.IsNullOrWhiteSpace(sortBy))
            //{
            //    sortBy = "Name";
            //}

            //return Content(String.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
        //}

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        // Adding multiple constraints like regex, range, min, max...
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    }
}