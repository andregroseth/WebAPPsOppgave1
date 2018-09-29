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
            var testUser = new User
            {
                Userlvl = 1,
                Email = "test@test.test",
                Firstname = "testname",
                Surname = "testsurname",
                Password = "testpassword",
                Address = "testaddress",
            };

            var testMovie = new Movie
            {
                Title = "The Matrix",
                Category = "Sci-Fi",
                Cost = 90,
                ImagePath = "~/Content/images/movie/matrix.jpg"
            };

            var testOrder = new Order
            {
                User = testUser,
                Date = "13.33.37"
            };

            var testMail = new Mail
            {
                ZipCode = "9999",
                Area = "bever"
            };

            var testOrderLine = new Orderline
            {
                Order = testOrder,
                Movie = testMovie
            };

            var testOrderlineList = new List<Orderline>();
            testOrderlineList.Add(testOrderLine);
            testOrder.Orderline = testOrderlineList;

            var testOrderList = new List<Order>();
            testOrderList.Add(testOrder);
            testUser.Order = testOrderList;
            testUser.Mail = testMail;

            context.User.Add(testUser);
            base.Seed(context);
        }
    }
}