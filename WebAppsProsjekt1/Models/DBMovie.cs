using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
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
    }
}