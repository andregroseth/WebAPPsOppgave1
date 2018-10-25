using System;
using System.Collections.Generic;
using System.Linq;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.DAL
{
    public class DBOrderStub : DAL.IDBOrder
    {
        public void AddOrder(List<Movie> inMovie, int id)
        {
            using (var db = new DB())
            {
                var user = db.User.FirstOrDefault(u => u.Id == id);

                var order = new Order()
                {
                    Date = DateTime.Now.Date.ToShortDateString(),
                    User = user
                };

                var orderlineList = new List<Orderline>();

                foreach (var movie in inMovie)
                {
                    var bla = db.Movie.FirstOrDefault(m => m.Id == movie.Id);

                    var newOrderline = new Orderline()
                    {
                        Order = order,
                        Movie = bla
                    };
                    orderlineList.Add(newOrderline);
                }
                order.Orderline = orderlineList;

                db.Order.Add(order);
                db.SaveChanges();
            }
        }

        public List<VMOrder> AllOrderInfo(int id)
        {
            if (id == 0)
            {
                var orderList = new List<VMOrder>();
                return orderList;
            }
            else
            {
                var orderList = new List<VMOrder>();
                var order = new VMOrder()
                {
                    Id = 1,
                    Date = "12/10/2018",
                    UserId = 1,
                };
                orderList.Add(order);
                orderList.Add(order);
                orderList.Add(order);
                return orderList;
            }
        }

        public bool DeleteOrder(int Id)
        {
            using (var db = new DB())
            {
                try
                {
                    var DeleteOrderlineRad = db.Orderline.Where(a => a.Order.Id == Id);
                    foreach (var item in DeleteOrderlineRad)
                    {
                        db.Orderline.Remove(item);
                    }
                    var DeleteOrderRad = db.Order.FirstOrDefault(u => u.Id == Id);
                    db.Order.Remove(DeleteOrderRad);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception error) { return false; }
            }

        }

        public List<VMOrderline> GetOrderInfo(int id, int userid)
        {
            var orderlineList = new List<VMOrderline>();
            if (id != 0)
            {
                var orderline = new VMOrderline()
                {
                    UserId = 1,
                    Id = 1,
                    MovieId = 1,
                    Title = "Test Title",
                    Category = "Test",
                    Cost = 123,
                    ImagePath = "Test"
                };
                orderlineList.Add(orderline);
                orderlineList.Add(orderline);
                orderlineList.Add(orderline);

                return orderlineList;
            }
            else
            {
                return orderlineList;
            }
        }
        }
}