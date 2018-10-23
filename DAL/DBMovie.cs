using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppsProsjekt1.Model;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.DAL
{ 
    public class DBMovie
    {
        public List<Movie> MovieGet()
        {
			HttpCookie cookie = HttpContext.Current.Request.Cookies["Cart"];
            List<Movie> movieList = new List<Movie>();
            if (cookie != null)
            {
				CookieHelper cookieHelper = new CookieHelper();
				using (var db = new DB())
                {
                    foreach (int id in cookieHelper.CookieParse(cookie))
                    {
                        movieList.Add(db.Movie.FirstOrDefault(b => b.Id == id));
                    }
                }
            }
            return movieList;
        }
        public List<Movie> AllMovies() {
            using (var db = new DB())
            {
                List<Movie> allMovies = db.Movie.ToList();
                return allMovies;
            }

        }
    }
}