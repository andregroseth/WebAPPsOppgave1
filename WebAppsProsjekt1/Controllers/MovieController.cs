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
        // GET: Movie/MovieList
        public ActionResult MovieList()
        {
            using (var db = new Models.DB())
            {
                List<Models.Movie> allMovies = db.Movie.ToList();
                return View(allMovies);
            }
        }

        public void AddMovieToCart(int id, string title)
        {
            int movieCounter = 0;

            HttpCookie cartCookie = new HttpCookie("cartCookie");
            cartCookie.Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies.Add(cartCookie);

            if (Request.Cookies["cartCookie"] == null)
            {
                Response.Cookies["cartCookie"].Value = Convert.ToString(id);
            }
            else
            {
                movieCounter = int.Parse(Request.Cookies["movieCounter"].Value);
                cartCookie.Values.Add(Convert.ToString(id), title);
                Response.Cookies["movieCounter"].Value = movieCounter.ToString();
                movieCounter++;
            }

        }
    }
}