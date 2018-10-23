using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppsProsjekt1.DAL;
using WebAppsProsjekt1.Model;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.BLL
{
    public class CartBLL
    {
        public List<Movie> MovieGet()
        {
            var db = new DBMovie();
            return db.MovieGet();
        }   
        public void AddOrder(List<Movie> inMovie, int id)
        {
        var db = new DBOrder();
        db.AddOrder(inMovie,id);       
        }
        public List<int> CookieParse(HttpCookie cookie)
        {
            var cookieHelper = new CookieHelper();
            return cookieHelper.CookieParse(cookie);
        }
        public void CookieDelete(HttpCookie cookie, HttpResponseBase response)
        {
            var cookieHelper = new CookieHelper();
            cookieHelper.CookieDelete(cookie,response);
        }
        public void CookieCartDelete(int id, HttpResponseBase response)
        {
            var cookieHelper = new CookieHelper();
            cookieHelper.CookieCartDelete(id,response);
        }
    }
}