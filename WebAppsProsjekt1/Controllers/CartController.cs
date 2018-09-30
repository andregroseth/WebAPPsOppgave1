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
            DBMovie ok = new DBMovie();
            return View(ok.MovieGet());
        }

        //[HttpPost]
        //public ActionResult CartList(List<Movie> movieList)
        //{
        //    return View();
        //}
    }
}