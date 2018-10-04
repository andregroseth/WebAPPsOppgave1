using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DbInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            List<Movie> MovieList = new List<Movie>
                {
                    new Movie
                    {
                        Title = "The Matrix",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/matrixImage.jpg"
                    },

                    new Movie
                    {
                        Title = "Bright",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/brightImage.jpg"
                    },

                    new Movie
                    {
                        Title = "Ant-Man",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/antmanImage.jpg"
                    },

                    new Movie
                    {
                        Title = "Back To The Future",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/backtothefuture.jpg"
                    },

                    new Movie
                    {
                        Title = "Black Panther",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/blackpanther.jpg"
                    },

                    new Movie
                    {
                        Title = "Deadpool 2",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/deadpool2.jpg"
                    },

                    new Movie
                    {
                        Title = "Gladiator",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/gladiatorImage.jpg"
                    },

                    new Movie
                    {
                        Title = "Hitch Hikers Guide",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/hitchhikersguide.jpg"
                    },

                    new Movie
                    {
                        Title = "Hitman",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/hitmanImage.jpg"
                    },

                    new Movie
                    {
                        Title = "iBoy",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/iboy.jpg"
                    },

                    new Movie
                    {
                        Title = "Inception",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/inception.jpg"
                    },

                    new Movie
                    {
                        Title = "Infinity War",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/infinitywar.jpg"
                    },

                    new Movie
                    {
                        Title = "Justice League",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/justiceleague.jpg"
                    },

                    new Movie
                    {
                        Title = "Kong Skull Island",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/kongImage.jpg"
                    },

                    new Movie
                    {
                        Title = "Limitless",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/limitless.jpg"
                    },

                    new Movie
                    {
                        Title = "Ready Player One",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/readyplayerone.jpg"
                    },

                    new Movie
                    {
                        Title = "Stars Wars Solo",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/solo.jpg"
                    },

                    new Movie
                    {
                        Title = "The Amazing Spider Man",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/theamazingspidermanImage.jpg"
                    },

                    new Movie
                    {
                        Title = "Tron",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/tron.jpg"
                    },

                    new Movie
                    {
                        Title = "Tron: Legacy",
                        Category = "Sci-Fi",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/tronlegacy.jpg"
                    }


                };

            var testMail = new Mail
            {
                ZipCode = "9999",
                Area = "test"
            };

            List<User> UserList = new List<User>
                {
                    new User
                    {
                        Userlvl = 1,
                        Email = "test@test.test",
                        Firstname = "testname",
                        Surname = "testsurname",
                        Password = "testpassword",
                        Address = "testaddress",
                        Mail = testMail,
                    },

                    new User
                    {
                        Userlvl = 1,
                        Email = "ola@gmail.com",
                        Firstname = "Ola",
                        Surname = "Nordmann",
                        Password = "hallo123",
                        Address = "Sinsenveien 14",
                        Mail = testMail,
                    },

                    new User
                    {
                        Userlvl = 0,
                        Email = "trude@oslomet.no",
                        Firstname = "Trude",
                        Surname = "Solberg",
                        Password = "prinsesse123",
                        Address = "Frognerveien 24B",
                        Mail = testMail,
                    },

                    new User
                    {
                        Userlvl = 2,
                        Email = "admin@oslomet.no",
                        Firstname = "Admin",
                        Surname = "Admin",
                        Password = "admin123",
                        Address = "Pilestredet 35",
                        Mail = testMail,
                    },

                };

            // Legger inn init-filmer til databasen
            foreach (var movie in MovieList)
            {
                context.Movie.Add(movie);
            }
            context.SaveChanges();

            // Legger inn init-brukere til databasen
            foreach (var user in UserList)
            {
                context.User.Add(user);
            }
            context.SaveChanges();

            // Legger inn init-ordrer til databasen
            foreach (var user in context.User)
            {
                context.Order.Add(new Order { User = user, Date = "12/10/2018" });
            }
            context.SaveChanges();

            // Legger inn init-ordrelinjer til databasen
            foreach (var order in context.Order)
            {    
                context.Orderline.Add(new Orderline { Order = order, Movie = MovieList.ElementAt(5) });
                
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}