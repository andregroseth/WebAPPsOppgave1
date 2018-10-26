using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppsProsjekt1.Model;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.DAL
{
    public class DBMovieStub : DAL.IDBMovie
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

        public List<Movie> AllMovies()
        {
            var movieList = new List<Movie>();
            var movie = new Movie()
            {
                Id = 1,
                Title = "The Matrix",
                Category = "Sci-Fi",
                Cost = 59,
                ImagePath = "/Content/images/movie/matrixImage.jpg",
                MovieSrc = "https://www.youtube.com/embed/m8e-FF8MsqU"
            };
            movieList.Add(movie);
            movieList.Add(movie);
            movieList.Add(movie);
            return movieList;
        }

        public bool addMovie(Movie inMovie)
        {
            if (inMovie.Title.ToString().Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool DeleteMovie(int id)
        {
            if (id != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Movie GetMovieInfo(int id)
        {
            if (id != null)
            {
                var movie = new Movie()
                {
                    Id = 1,
                    Title = "The Matrix",
                    Category = "Sci-Fi",
                    Cost = 59,
                    ImagePath = "/Content/images/movie/matrixImage.jpg",
                    MovieSrc = "https://www.youtube.com/embed/m8e-FF8MsqU"
                };
                return movie;
            }
            else
            {
                var movie = new Movie();
                movie.Title = "";
                return movie;
            }
        }

        public bool EditMovie(int id, Movie inMovie)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}