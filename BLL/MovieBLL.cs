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
    public class MovieBLL : BLL.IMovieBLL
    {
        private IDBMovie db;
        public MovieBLL()
        {
            db = new DBMovie();
        }

        public MovieBLL(IDBMovie stub)
        {
            db = stub;
        }

        public List<Movie> AllMovies()
        {
            var db = new DBMovie();
            return db.AllMovies();
        }
        public bool addMovie(Movie inMovie){
            var db = new DBMovie();
            return db.addMovie(inMovie);
        }
        public bool DeleteMovie(int id) {
            var db = new DBMovie();
            return db.DeleteMovie(id);
        }
        public Movie GetMovieInfo(int id) {
            var db = new DBMovie();
            return db.GetMovieInfo(id) ;
        }
        public bool EditMovie(int id, Movie inMovie) {
            var db = new DBMovie();
            return db.EditMovie(id,inMovie);
        }
    }
}
