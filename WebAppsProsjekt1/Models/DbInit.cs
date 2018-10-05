using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    //public class DbInit : DropCreateDatabaseAlways<DB>
        public class DbInit : CreateDatabaseIfNotExists<DB>
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
                    },

                    new Movie
                    {
                        Title = "Kingsman: The Secret Service",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/kingsman.jpg"
                    },

                    new Movie
                    {
                        Title = "The Wolf of Wall Street",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/thewolfofwallstreet.jpg"
                    },

                    new Movie
                    {
                        Title = "Holmes and Watson",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/holmesandwatson.jpg"
                    },

                    new Movie
                    {
                        Title = "The Naked Gun",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/thenakedgun.jpg"
                    },

                    new Movie
                    {
                        Title = "Sausage Party",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/sausageparty.jpg"
                    },

                    new Movie
                    {
                        Title = "Kick-Ass",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/kickass.jpg"
                    },

                    new Movie
                    {
                        Title = "The Mask",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/themask.jpg"
                    },

                    new Movie
                    {
                        Title = "Cars",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/cars.jpg"
                    },

                    new Movie
                    {
                        Title = "Shrek",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/shrek.jpg"
                    },

                    new Movie
                    {
                        Title = "Home Alone",
                        Category = "Comedy",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/homealone.jpg"
                    },

                    new Movie
                    {
                        Title = "The Dark Knight",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/thedarkknight.jpg"
                    },

                    new Movie
                    {
                        Title = "The God Father",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/thegodfather.jpg"
                    },

                    new Movie
                    {
                        Title = "Pulp Fiction",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/pulpfiction.jpg"
                    },

                    new Movie
                    {
                        Title = "The Girl wit the Dragon Tattoo",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/thegirlwiththedragontattoo.jpg"
                    },

                    new Movie
                    {
                        Title = "Inferno",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/inferno.jpg"
                    },

                    new Movie
                    {
                        Title = "Sherlock Holmes",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/sherlockholmes.jpg"
                    },

                    new Movie
                    {
                        Title = "Shooter",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/shooter.jpg"
                    },

                    new Movie
                    {
                        Title = "Fast & Furious 7",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/furious7.jpg"
                    },

                    new Movie
                    {
                        Title = "Taken",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/taken.jpg"
                    },

                    new Movie
                    {
                        Title = "The Punisher",
                        Category = "Crime",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/punisher.jpg"
                    },

                    new Movie
                    {
                        Title = "From Dusk Till Dawn",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/fromdusktilldawn.jpg"
                    },

                    new Movie
                    {
                        Title = "Halloween",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/halloween.jpg"
                    },

                    new Movie
                    {
                        Title = "The Purge",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/thepurge.jpg"
                    },

                    new Movie
                    {
                        Title = "The Babysitter",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/thebabysitter.jpg"
                    },

                    new Movie
                    {
                        Title = "Dracula",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/dracula.jpg"
                    },

                    new Movie
                    {
                        Title = "Legion",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/legion.jpg"
                    },

                    new Movie
                    {
                        Title = "Sleepy Hollow",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/sleepyhollow.jpg"
                    },

                    new Movie
                    {
                        Title = "Friday the 13th",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/friday13th.jpg"
                    },

                    new Movie
                    {
                        Title = "Resident Evil",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/residentevil.jpg"
                    },

                    new Movie
                    {
                        Title = "Dawn of the Dead",
                        Category = "Horror",
                        Cost = 90,
                        ImagePath = "/Content/images/movie/dawnofthedead.jpg"
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