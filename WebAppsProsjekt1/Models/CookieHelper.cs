using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Text.RegularExpressions;

namespace WebAppsProsjekt1.Models
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