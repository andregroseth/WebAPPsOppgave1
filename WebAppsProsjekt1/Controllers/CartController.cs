﻿using System;
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
            var db = new DBMovie();
            CookieHelper cookieHelper = new CookieHelper();
            HttpCookie cookie = Request.Cookies["Cart"];
            List<int> cookieList = cookieHelper.CookieParse(cookie);
            return View(db.MovieGet(cookieList));
        }

        [HttpPost]
        public ActionResult CartList(List<Movie> movieList)
        {
            if(Session["Login"] != null)
            {
				CookieHelper cookieHelper = new CookieHelper();
				HttpCookie cartCookie = Request.Cookies["Cart"];
				if (cartCookie == null || cookieHelper.CookieParse(cartCookie).Count < 1)
				{
					Session["PurchaseFailedEmpty"] = "true";
					return RedirectToAction("MovieList", "Movie");
				}
					
				DBOrder db = new DBOrder();
				int.TryParse(Session["Login"].ToString(), out int userId);
				db.AddOrder(movieList, userId);
				cookieHelper.CookieDelete(cartCookie, Response);

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
                var cookieHelper = new CookieHelper();
                cookieHelper.CookieDelete(Request.Cookies["Cart"], Response);
            }
            return RedirectToAction("CartList");
        }

        public ActionResult CartDelete() {

            HttpCookie cookie = Request.Cookies["Cart"];
            CookieHelper cookieHelper = new CookieHelper();
            cookieHelper.CookieParse(cookie);

            return RedirectToAction("CartList");
        }
    }
}