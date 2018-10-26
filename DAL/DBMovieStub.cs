﻿using System;
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
            if (inMovie.Equals(null))
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