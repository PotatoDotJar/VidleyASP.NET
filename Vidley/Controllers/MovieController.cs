using System.Collections.Generic;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Title = "The Bee Movie" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // GET: Movie/Edit/{id}
        public ActionResult Edit(int id)
        {
            return Content("ID=" + id);
        }

        public ActionResult Index(int? pageNumber, string sortBy)
        {
            if(!pageNumber.HasValue)
            {
                pageNumber = 1;
            }

            if(string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(string.Format("pageNumber={0}&sortBy={1}", pageNumber, sortBy));
        }

        // Other possible attribute route constraints are: min, max, minlength, maxlength, int, float, guid
        [Route("movies/released/{year:regex(\\d{4}):range(1990, 2018)}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("{0}/{1}", year, month));
        }
    }
}
