using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;

namespace Vidley.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Title = "The Bee Movie" };

            return View(movie);
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

            if(String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageNumber={0}&sortBy={1}", pageNumber, sortBy));
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("{0}/{1}", year, month));
        }
    }
}

//https://youtu.be/E7Voso411Vs?t=2439