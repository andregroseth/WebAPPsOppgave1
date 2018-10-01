using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult CartList()
        {
            DBMovie db = new DBMovie();
            return View(db.MovieGet());
        }

        [HttpPost]
        public ActionResult CartList(List<Movie> movieList)
        {
            var dbMovie = new DBMovie();
            movieList = dbMovie.MovieGet();
            if(Session["Login"] != null)
            {
                var db = new DBOrder();
                int userId;
                int.TryParse(Session["Login"].ToString(), out userId);
                db.AddOrder(movieList, userId);
            } else
            {
                return RedirectToAction("UserLogin", "User");
            }
            return RedirectToAction("MovieList", "Movie");
        }
    }
}