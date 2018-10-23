using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppsProsjekt1.DAL;
using WebAppsProsjekt1.Model;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.BLL
{
    public class MovieBLL
    {
        public List<Movie> AllMovies()
        {
            var db = new DBMovie();
            return db.AllMovies();
        }
    }
}
