using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{       //bruk DropCreateDatabaseAlways lokalt og CreateDatabaseIfNotExists ved publish til Azure.Ved endringer i database struktur må sql server i Azure cloud slettes og det må opprettes en ny.
        public class DbInit : CreateDatabaseIfNotExists<DB>

        // public class DbInit : DropCreateDatabaseAlways<DB>
		{
			protected override void Seed(DB context)
			{
				List<Movie> MovieList = new List<Movie>
				{
					new Movie
					{
						Title = "The Matrix",
						Category = "Sci-Fi",
						Cost = 59,
						ImagePath = "/Content/images/movie/matrixImage.jpg",
                        MovieSrc = "https://www.youtube.com/embed/m8e-FF8MsqU"
                    },

					new Movie
					{
						Title = "Bright",
						Category = "Sci-Fi",
						Cost = 129,
						ImagePath = "/Content/images/movie/brightImage.jpg",
                        MovieSrc = "https://www.youtube.com/embed/6EZCBSsBxko"
                    },

					new Movie
					{
						Title = "Ant-Man",
						Category = "Sci-Fi",
						Cost = 129,
						ImagePath = "/Content/images/movie/antmanImage.jpg",
                        MovieSrc = "https://www.youtube.com/embed/pWdKf3MneyI"
                    },

					new Movie
					{
						Title = "Back To The Future",
						Category = "Sci-Fi",
						Cost = 59,
						ImagePath = "/Content/images/movie/backtothefuture.jpg",
                        MovieSrc = "https://www.youtube.com/embed/yosuvf7Unmg"
                    },

					new Movie
					{
						Title = "Black Panther",
						Category = "Sci-Fi",
						Cost = 159,
						ImagePath = "/Content/images/movie/blackpanther.jpg",
                        MovieSrc = "https://www.youtube.com/embed/xjDjIWPwcPU"
                    },

					new Movie
					{
						Title = "Deadpool 2",
						Category = "Sci-Fi",
						Cost = 129,
						ImagePath = "/Content/images/movie/deadpool2.jpg",
                        MovieSrc = "https://www.youtube.com/embed/D86RtevtfrA"
                    },

					new Movie
					{
						Title = "Gladiator",
						Category = "Sci-Fi",
						Cost = 59,
						ImagePath = "/Content/images/movie/gladiatorImage.jpg",
                        MovieSrc = "https://www.youtube.com/embed/owK1qxDselE"
                    },

					new Movie
					{
						Title = "Hitch Hikers Guide",
						Category = "Sci-Fi",
						Cost = 59,
						ImagePath = "/Content/images/movie/hitchhikersguide.jpg",
                        MovieSrc = "https://www.youtube.com/embed/MbGNcoB2Y4I"
                    },

					new Movie
					{
						Title = "Hitman",
						Category = "Sci-Fi",
						Cost = 59,
						ImagePath = "/Content/images/movie/hitmanImage.jpg",
                        MovieSrc = "https://www.youtube.com/embed/alQlJDRnQkE"
                    },

					new Movie
					{
						Title = "iBoy",
						Category = "Sci-Fi",
						Cost = 59,
						ImagePath = "/Content/images/movie/iboy.jpg",
                        MovieSrc = "https://www.youtube.com/embed/FbEWtpSmJXg"
                    },

					new Movie
					{
						Title = "Inception",
						Category = "Sci-Fi",
						Cost = 129,
						ImagePath = "/Content/images/movie/inception.jpg",
                        MovieSrc = "https://www.youtube.com/embed/8hP9D6kZseM"
                    },

					new Movie
					{
						Title = "Infinity War",
						Category = "Sci-Fi",
						Cost = 159,
						ImagePath = "/Content/images/movie/infinitywar.jpg",
                        MovieSrc = "https://www.youtube.com/embed/6ZfuNTqbHE8"
                    },

					new Movie
					{
						Title = "Justice League",
						Category = "Sci-Fi",
						Cost = 159,
						ImagePath = "/Content/images/movie/justiceleague.jpg",
                        MovieSrc = "https://www.youtube.com/embed/3cxixDgHUYw"
                    },

					new Movie
					{
						Title = "Kong Skull Island",
						Category = "Sci-Fi",
						Cost = 129,
						ImagePath = "/Content/images/movie/kongImage.jpg",
                        MovieSrc = "https://www.youtube.com/embed/44LdLqgOpjo"
                    },

					new Movie
					{
						Title = "Limitless",
						Category = "Sci-Fi",
						Cost = 59,
						ImagePath = "/Content/images/movie/limitless.jpg",
                        MovieSrc = "https://www.youtube.com/embed/4TLppsfzQH8"
                    },

					new Movie
					{
						Title = "Ready Player One",
						Category = "Sci-Fi",
						Cost = 159,
						ImagePath = "/Content/images/movie/readyplayerone.jpg",
                        MovieSrc = "https://www.youtube.com/embed/cSp1dM2Vj48"
                    },

					new Movie
					{
						Title = "Solo: A Star Wars Story",
						Category = "Sci-Fi",
						Cost = 129,
						ImagePath = "/Content/images/movie/solo.jpg",
                        MovieSrc = "https://www.youtube.com/embed/jPEYpryMp2s"
                    },

					new Movie
					{
						Title = "The Amazing Spider Man",
						Category = "Sci-Fi",
						Cost = 129,
						ImagePath = "/Content/images/movie/theamazingspidermanImage.jpg",
                        MovieSrc = "https://www.youtube.com/embed/DlM2CWNTQ84"
                    },

					new Movie
					{
						Title = "Tron",
						Category = "Sci-Fi",
						Cost = 59,
						ImagePath = "/Content/images/movie/tron.jpg",
                        MovieSrc = "https://www.youtube.com/embed/3efV2wqEjEY"
                    },

					new Movie
					{
						Title = "Tron: Legacy",
						Category = "Sci-Fi",
						Cost = 129,
						ImagePath = "/Content/images/movie/tronlegacy.jpg",
                        MovieSrc = "https://www.youtube.com/embed/L9szn1QQfas"
                    },

					new Movie
					{
						Title = "Kingsman: The Secret Service",
						Category = "Comedy",
						Cost = 129,
						ImagePath = "/Content/images/movie/kingsman.jpg",
                        MovieSrc = "https://www.youtube.com/embed/m4NCribDx4U"
                    },

					new Movie
					{
						Title = "The Wolf of Wall Street",
						Category = "Comedy",
						Cost = 129,
						ImagePath = "/Content/images/movie/thewolfofwallstreet.jpg",
                        MovieSrc = "https://www.youtube.com/embed/iszwuX1AK6A"
                    },

					new Movie
					{
						Title = "Holmes and Watson",
						Category = "Comedy",
						Cost = 59,
						ImagePath = "/Content/images/movie/holmesandwatson.jpg",
                        MovieSrc = "https://www.youtube.com/embed/brjkpRBpFnc"
                    },

					new Movie
					{
						Title = "The Naked Gun",
						Category = "Comedy",
						Cost = 59,
						ImagePath = "/Content/images/movie/thenakedgun.jpg",
                        MovieSrc = "https://www.youtube.com/embed/PACTQutbow4"
                    },

					new Movie
					{
						Title = "Sausage Party",
						Category = "Comedy",
						Cost = 129,
						ImagePath = "/Content/images/movie/sausageparty.jpg",
                        MovieSrc = "https://www.youtube.com/embed/WVAcTZKTgmc"
                    },

					new Movie
					{
						Title = "Kick-Ass",
						Category = "Comedy",
						Cost = 59,
						ImagePath = "/Content/images/movie/kickass.jpg",
                        MovieSrc = "https://www.youtube.com/embed/rFpWpkxsVI8"
                    },

					new Movie
					{
						Title = "The Mask",
						Category = "Comedy",
						Cost = 59,
						ImagePath = "/Content/images/movie/themask.jpg",
                        MovieSrc = "https://www.youtube.com/embed/hOqVRwGVUkA"
                    },

					new Movie
					{
						Title = "Cars",
						Category = "Comedy",
						Cost = 59,
						ImagePath = "/Content/images/movie/cars.jpg",
                        MovieSrc = "https://www.youtube.com/embed/SbXIj2T-_uk"
                    },

					new Movie
					{
						Title = "Shrek",
						Category = "Comedy",
						Cost = 59,
						ImagePath = "/Content/images/movie/shrek.jpg",
                        MovieSrc = "https://www.youtube.com/embed/W37DlG1i61s"
                    },

					new Movie
					{
						Title = "Home Alone",
						Category = "Comedy",
						Cost = 59,
						ImagePath = "/Content/images/movie/homealone.jpg",
                        MovieSrc = "https://www.youtube.com/embed/jEDaVHmw7r4"
                    },

					new Movie
					{
						Title = "The Dark Knight",
						Category = "Crime",
						Cost = 129,
						ImagePath = "/Content/images/movie/thedarkknight.jpg",
                        MovieSrc = "https://www.youtube.com/embed/EXeTwQWrcwY"
                    },

					new Movie
					{
						Title = "The God Father",
						Category = "Crime",
						Cost = 129,
						ImagePath = "/Content/images/movie/thegodfather.jpg",
                        MovieSrc = "https://www.youtube.com/embed/sY1S34973zA"
                    },

					new Movie
					{
						Title = "Pulp Fiction",
						Category = "Crime",
						Cost = 59,
						ImagePath = "/Content/images/movie/pulpfiction.jpg",
                        MovieSrc = "https://www.youtube.com/embed/s7EdQ4FqbhY"
                    },

					new Movie
					{
						Title = "The Girl wit the Dragon Tattoo",
						Category = "Crime",
						Cost = 59,
						ImagePath = "/Content/images/movie/thegirlwiththedragontattoo.jpg",
                        MovieSrc = "https://www.youtube.com/embed/DqQe3OrsMKI"
                    },

					new Movie
					{
						Title = "Inferno",
						Category = "Crime",
						Cost = 59,
						ImagePath = "/Content/images/movie/inferno.jpg",
                        MovieSrc = "https://www.youtube.com/embed/RH2BD49sEZI"
                    },

					new Movie
					{
						Title = "Sherlock Holmes",
						Category = "Crime",
						Cost = 59,
						ImagePath = "/Content/images/movie/sherlockholmes.jpg",
                        MovieSrc = "https://www.youtube.com/embed/J7nJksXDBWc"
                    },

					new Movie
					{
						Title = "Shooter",
						Category = "Crime",
						Cost = 59,
						ImagePath = "/Content/images/movie/shooter.jpg",
                        MovieSrc = "https://www.youtube.com/embed/6ZVcPhDt-kM"
                    },

					new Movie
					{
						Title = "Fast & Furious 7",
						Category = "Crime",
						Cost = 129,
						ImagePath = "/Content/images/movie/furious7.jpg",
                        MovieSrc = "https://www.youtube.com/embed/Skpu5HaVkOc"
                    },

					new Movie
					{
						Title = "Taken",
						Category = "Crime",
						Cost = 59,
						ImagePath = "/Content/images/movie/taken.jpg",
                        MovieSrc = "https://www.youtube.com/embed/kZ02_Uzf7So"
                    },

					new Movie
					{
						Title = "The Punisher",
						Category = "Crime",
						Cost = 59,
						ImagePath = "/Content/images/movie/punisher.jpg",
                        MovieSrc = "https://www.youtube.com/embed/q7CMnRv8Mqc"
                    },

					new Movie
					{
						Title = "From Dusk Till Dawn",
						Category = "Horror",
						Cost = 129,
						ImagePath = "/Content/images/movie/fromdusktilldawn.jpg",
                        MovieSrc = "https://www.youtube.com/embed/6RF0hYk7tc8"
                    },

					new Movie
					{
						Title = "Halloween",
						Category = "Horror",
						Cost = 159,
						ImagePath = "/Content/images/movie/halloween.jpg",
                        MovieSrc = "https://www.youtube.com/embed/ek1ePFp-nBI"
                    },

					new Movie
					{
						Title = "The Purge",
						Category = "Horror",
						Cost = 159,
						ImagePath = "/Content/images/movie/thepurge.jpg",
                        MovieSrc = "https://www.youtube.com/embed/K0LLaybEuzA"
                    },

					new Movie
					{
						Title = "The Babysitter",
						Category = "Horror",
						Cost = 59,
						ImagePath = "/Content/images/movie/thebabysitter.jpg",
                        MovieSrc = "https://www.youtube.com/embed/CQTEUd-5JMQ"
                    },

					new Movie
					{
						Title = "Dracula",
						Category = "Horror",
						Cost = 59,
						ImagePath = "/Content/images/movie/dracula.jpg",
                        MovieSrc = "https://www.youtube.com/embed/UrW2wng-MYc"
                    },

					new Movie
					{
						Title = "Legion",
						Category = "Horror",
						Cost = 129,
						ImagePath = "/Content/images/movie/legion.jpg",
                        MovieSrc = "https://www.youtube.com/embed/4SZ3rMMYBLY"
                    },

					new Movie
					{
						Title = "Sleepy Hollow",
						Category = "Horror",
						Cost = 59,
						ImagePath = "/Content/images/movie/sleepyhollow.jpg",
                        MovieSrc = "https://www.youtube.com/embed/R6O4Himch7g"
                    },

					new Movie
					{
						Title = "Friday the 13th",
						Category = "Horror",
						Cost = 129,
						ImagePath = "/Content/images/movie/friday13th.jpg",
                        MovieSrc = "https://www.youtube.com/embed/cCfO1aB8CIE"
                    },

					new Movie
					{
						Title = "Resident Evil",
						Category = "Horror",
						Cost = 129,
						ImagePath = "/Content/images/movie/residentevil.jpg",
                        MovieSrc = "https://www.youtube.com/embed/kEutwdia8n0"
                    },

					new Movie
					{
						Title = "Dawn of the Dead",
						Category = "Horror",
						Cost = 59,
						ImagePath = "/Content/images/movie/dawnofthedead.jpg",
                        MovieSrc = "https://www.youtube.com/embed/fEPIOdFtQ0Y"
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