using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;

namespace WebAppsProsjekt1.Models
{
	public class CookieHelper
	{
		public void CookieDelete(HttpCookie cookie, HttpResponseBase response) {
			cookie.Expires = DateTime.Now.AddDays(-10);
			response.SetCookie(cookie);
		}
	}
}