using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
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
        public ActionResult MovieListAdminView()
        {
            var db = new MovieBLL();
            return View(db.AllMovies());
        }
        public ActionResult MovieAdd() {
            return View();
        }
        [HttpPost]
        public ActionResult MovieAdd(Movie inMovie) {
            var db = new MovieBLL();
            if (ModelState.IsValid) {
                bool OK = db.addMovie(inMovie);
                if (OK) {
                    return RedirectToAction("MovieListAdminView");
                }
            }
            return View();
        }
        public ActionResult MovieDelete(int id)
        {
            var db = new MovieBLL();
            try
            {
                int.TryParse(Session["Userlevel"].ToString(), out int userlevel);
                if (userlevel > 0)
                {
                    db.DeleteMovie(id);
					Session["DeleteSuccess"] = "true";
					System.Diagnostics.Debug.WriteLine(Session["DeleteSuccess"].ToString());
					return RedirectToAction("MovieListAdminView", "Movie");
                }
                else
                {
                    Session["AccessFailedAdmin"] = "true";
                    return RedirectToAction("MovieList", "Movie");
                }
            }
            catch
            {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult MovieEdit(int id) {
            var db = new MovieBLL();
            Movie oneMovie = db.GetMovieInfo(id);
            return View(oneMovie);
        }
        [HttpPost]
        public ActionResult MovieEdit(int id, Movie inMovie) {
            var db = new MovieBLL();
            bool EditOk = db.EditMovie(id, inMovie);
            if (EditOk)
            {
                return RedirectToAction("MovieListAdminView");
            }
            return View();
        }
    
    }
}