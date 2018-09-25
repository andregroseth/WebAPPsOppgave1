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
        // GET: Movie
        public ActionResult ListAllMovies()
        {
            var movie = new Movie() { Title = "Shrek" };
            return View(movie);
        }
    }
}