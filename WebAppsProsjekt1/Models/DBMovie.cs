using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DBMovie
    {
        public List<Movie> MovieGet()
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["cartCookie"];
            List<Movie> movieList = new List<Movie>();
            if (cookie != null)
            {
                using (var db = new DB())
                {
                    foreach (int id in CookieParse(cookie))
                    {
                        movieList.Add(db.Movie.FirstOrDefault(b => b.Id == id));
                    }
                }
            }
            return movieList;
        }

        private List<int> CookieParse(HttpCookie cookie)
        {
            List<int> idList = new List<int>();
            string cookieString = cookie.Value.ToString();
            string[] number = Regex.Split(cookieString, @"\D+");

            foreach (string value in number)
            {
                int parsedValue;
                Int32.TryParse(value, out parsedValue);
                if (parsedValue >= 1)
                {
                    idList.Add(parsedValue);
                }
            }
            return idList;
        }
    }
}