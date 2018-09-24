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
        // GET: Film
        public ActionResult MovieView1()
        {
            var movie = new Movie() { Name = "Shrek" };
            return View(movie);
        }
    }
}