using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DBMovie
    {
        private List<String> parseCookie(HttpCookie cookie)
        {
            List<String> idList = new List<String>();
            
            string cookieString = cookie.Value.ToString();
            //string parsedId = cookieString.Replace()
            foreach (char c in cookieString)
            {
                if (int.TryParse(c.ToString(), out _))
                {
                    idList.Add(c.ToString());
                }
                if (c.ToString() == "=")
                {
                    idList.Add(",");
                }
            }

            return idList;
        }
        //private int extractInt(String cookieString)
        //{

        //    return;
        //}
        public void GetMovies()
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["cartCookie"];
            if (cookie != null)
            {
                foreach (string item in parseCookie(cookie))
                {
                    System.Diagnostics.Debug.WriteLine(item);
                }
            }
            else
            {
                
            }
        }
    }
}