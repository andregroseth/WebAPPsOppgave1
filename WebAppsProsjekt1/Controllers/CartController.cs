using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsProsjekt1.BLL;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult CartList()
        {
            var db = new CartBLL();
            return View(db.MovieGet());
        }

        [HttpPost]
        public ActionResult CartList(List<Movie> movieList)
        {
            if(Session["Login"] != null)
            {
                var db = new CartBLL();
                HttpCookie cartCookie = Request.Cookies["Cart"];
				if (cartCookie == null || db.CookieParse(cartCookie).Count < 1)
				{
					Session["PurchaseFailedEmpty"] = "true";
					return RedirectToAction("MovieList", "Movie");
				}
				int.TryParse(Session["Login"].ToString(), out int userId);
				db.AddOrder(movieList, userId);
				db.CookieDelete(cartCookie, Response);

				Session["PurchaseSuccess"] = "true";
				return RedirectToAction("MovieList", "Movie");
			} else
            {
				Session["PurchaseFailedLogin"] = "true";
                return RedirectToAction("UserLogin", "User");
            }
        }

        public ActionResult CartClear() {
            HttpCookie cookie = Request.Cookies["Cart"];
            if (cookie != null) {
                var db = new CartBLL();
                db.CookieDelete(Request.Cookies["Cart"], Response);
            }
            return RedirectToAction("CartList");
        }

        public ActionResult CartDelete(int id) {

            var cookieHelper = new CartBLL();
            cookieHelper.CookieCartDelete(id, Response);
            return RedirectToAction("CartList");
        }
    }
}