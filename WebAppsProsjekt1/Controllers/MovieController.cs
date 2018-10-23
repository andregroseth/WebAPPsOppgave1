using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsProsjekt1.BLL;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/MovieList
        public ActionResult MovieList()
        {
            var db = new MovieBLL();
            return View(db.AllMovies());
        }

        public void AddMovieToCart(int id)
        {
            HttpCookie cartCookie;
			if (Request.Cookies["Cart"] == null)
			{
                cartCookie = new HttpCookie("Cart");
				cartCookie.Expires = DateTime.Now.AddMinutes(30);

                cartCookie.Values.Add(id.ToString(), "");
                Response.Cookies.Add(cartCookie);
            }
            else
            {
                cartCookie = Request.Cookies["Cart"];
                cartCookie.Values.Add(id.ToString(), "");
				cartCookie.Expires = DateTime.Now.AddMinutes(10);
				Response.Cookies.Add(cartCookie);
            }

        }
    }
}