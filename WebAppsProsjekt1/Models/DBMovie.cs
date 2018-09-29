using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DBMovie
    {
        public Movie getMovie(int id)
        {
            var db = new DB();
            var oneMovie = db.Movie.Find(id);
            if (oneMovie == null)
            {
                return null;
            }
            else
            {
                var oneMovieOuptput = new Movie()
                {
                    Id = oneMovie.Id,
                    Userlvl = oneUser.Userlvl,
                    Email = oneUser.Email,
                    Name = oneUser.Name,
                    Surname = oneUser.Surname,
                    Password = oneUser.Password,
                    Address = oneUser.Address,
                    ZipCode = oneUser.Mail.ZipCode,
                    Area = oneUser.Mail.Area

                };
                return oneMovieOuptput;
            }
        }
    }
}