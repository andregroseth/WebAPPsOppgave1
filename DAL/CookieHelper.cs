using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace WebAppsProsjekt1.DAL
{
	public class CookieHelper
	{
		public void CookieDelete(HttpCookie cookie, HttpResponseBase response) {
			cookie.Expires = DateTime.Now.AddDays(-10);
			response.SetCookie(cookie);
		}

		public List<int> CookieParse(HttpCookie cookie)
		{
			List<int> idList = new List<int>();
            if (cookie != null) {
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
            }
			return idList;
		}

        public void CookieCartDelete(int id, HttpResponseBase response) {

            HttpCookie cookie = HttpContext.Current.Request.Cookies["Cart"];
            List<int> idList = CookieParse(cookie);
            idList.Remove(id);           
            StringBuilder newCookie = new StringBuilder();
            foreach (var item in idList) {
                newCookie.Append(item.ToString());
                newCookie.Append("=&");
            }
            cookie.Value = newCookie.ToString();
            response.Cookies.Add(cookie);
        }
	}
}