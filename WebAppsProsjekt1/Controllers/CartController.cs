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
        public ActionResult CartList(int id)
        {
            using (var db = new Models.DB())
            {
                Movie cartMovie = db.getMovie(id);
                return View(cartMovies);
            }
        }
    }
}