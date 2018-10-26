using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppsProsjekt1.Model;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.DAL
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
        public List<Movie> AllMovies() {
            using (var db = new DB())
            {
                List<Movie> allMovies = db.Movie.ToList();
                return allMovies;
            }

        }
        public bool addMovie(Movie inMovie) {
            try
            {
                using (var db = new DB())
                {
                    var newMovie = new Movie()
                    {
                        Title = inMovie.Title,
                        Category = inMovie.Category,
                        Cost = inMovie.Cost,
                        ImagePath = inMovie.ImagePath,
                        MovieSrc = inMovie.MovieSrc
                    };
                    db.Movie.Add(newMovie);
					DBLogger logger = new DBLogger();
					db.addExtrasToEntries(db.ChangeTracker);
					logger.logChanges(db);
					db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteMovie(int id)
        {
            using (var db = new DB())
            {
                try
                {
                    var DeleteMovie = db.Movie.FirstOrDefault(m => m.Id == id);
                    var DeleteOrderLineRad = db.Orderline.Where(x => x.Movie.Id == DeleteMovie.Id).ToList();
                    if (DeleteOrderLineRad != null)
                    {
                        foreach (var item in DeleteOrderLineRad)
                        {                           
                                db.Orderline.Remove(item);
                        }
                    }
                    db.Movie.Remove(DeleteMovie);
					DBLogger logger = new DBLogger();
					db.addExtrasToEntries(db.ChangeTracker);
					logger.logChanges(db);
					db.SaveChanges();
					return true;
                }
                catch (Exception error) { return false; }
            }
        }
        public Movie GetMovieInfo(int id)
        {
            using (var db = new DB())
            {
                var oneMovie = db.Movie.Find(id);
                if (oneMovie == null)
                {
                    return null;
                }
                else
                {
                    var oneMovieOutput = new Movie()
                    {
                        Title = oneMovie.Title,
                        Category = oneMovie.Category,
                        Cost = oneMovie.Cost,
                        ImagePath = oneMovie.ImagePath,
                        MovieSrc = oneMovie.MovieSrc
                    };
                    return oneMovieOutput;
                }
            }
        }
        public bool EditMovie(int id, Movie inMovie)
        {
            var db = new DB();
            try
            {
                Movie find = db.Movie.Find(id);
                find.Title = inMovie.Title;
                find.Category = inMovie.Category;
                find.Cost = inMovie.Cost;
                find.ImagePath = inMovie.ImagePath;
                find.MovieSrc = inMovie.MovieSrc;
				DBLogger logger = new DBLogger();
				db.addExtrasToEntries(db.ChangeTracker);
				logger.logChanges(db);
				db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}