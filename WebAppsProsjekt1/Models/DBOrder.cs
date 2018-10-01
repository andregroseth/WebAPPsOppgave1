using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DBOrder
    {
        public void AddOrder(List<Movie> inMovie, int id)
        {
            
            using (var db = new DB())
            {
                var user = db.User.FirstOrDefault(u => u.Id == id);

                var order = new Order()
                {
                    Date = DateTime.Today.ToString(),
                    User = user
                };

                var orderlineList = new List<Orderline>();

                foreach (var movie in inMovie)
                {
                    var bla = db.Movie.FirstOrDefault(m=>m.Id == movie.Id);
            
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

        public List<OrderHelper> AllOrderInfo()
        {
            using (var db = new DB())
            {
                List<OrderHelper> AllOrderInfo = db.Order.Select(k => new OrderHelper
                {
                    Id = k.Id,
                    Date= k.Date,
                    UserId=k.User.Id
                }).ToList();

                return AllOrderInfo;
            }

        }
        public bool DeleteOrder(int Id)
        {
            using (var db = new DB())
            {
                try
                {
                    var DeleteOrderlineRad = db.Orderline.Where(a=>a.Order.Id== Id);
                    foreach (var item in DeleteOrderlineRad) {
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
    }
}