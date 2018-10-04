using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DBMovie
    {
        public List<Movie> MovieGet(List<int> cookieList)
        { 
            List<Movie> movieList = new List<Movie>();
            if (cookieList != null)
            {
				CookieHelper cookieHelper = new CookieHelper();
				using (var db = new DB())
                {
                    foreach (int id in cookieList)
                    {
                        movieList.Add(db.Movie.FirstOrDefault(b => b.Id == id));
                    }
                }
            }
            return movieList;
        }
    }
}