using System.Collections.Generic;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.BLL
{
    public interface IMovieBLL
    {
        bool addMovie(Movie inMovie);
        List<Movie> AllMovies();
        bool DeleteMovie(int id);
        bool EditMovie(int id, Movie inMovie);
        Movie GetMovieInfo(int id);
    }
}