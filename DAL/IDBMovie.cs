using System.Collections.Generic;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.DAL
{
    public interface IDBMovie
    {
        bool addMovie(Movie inMovie);
        List<Movie> AllMovies();
        bool DeleteMovie(int id);
        bool EditMovie(int id, Movie inMovie);
        Movie GetMovieInfo(int id);
        List<Movie> MovieGet();
    }
}