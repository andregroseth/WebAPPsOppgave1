using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/ListMovie
        public ActionResult ListMovie()
        {
            using (var db = new Models.DB())
            {

                List<Models.Movie> allMovies = db.Movie.ToList();
                return View(allMovies);
            }
        }

        public void addToCart()
        {

        }
    }
}