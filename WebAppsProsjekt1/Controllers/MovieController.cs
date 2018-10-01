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

        public void AddMovieToCart(int id)
        {
            HttpCookie cartCookie;
			if (Request.Cookies["cartCookie"] == null)
			{
                cartCookie = new HttpCookie("cartCookie");
				cartCookie.Expires = DateTime.Now.AddMinutes(30);

                cartCookie.Values.Add(id.ToString(), "");
                Response.Cookies.Add(cartCookie);
            }
            else
            {
                cartCookie = Request.Cookies["cartCookie"];
                cartCookie.Values.Add(id.ToString(), "");
				cartCookie.Expires = DateTime.Now.AddMinutes(10);
				Response.Cookies.Add(cartCookie);
            }

        }
    }
}