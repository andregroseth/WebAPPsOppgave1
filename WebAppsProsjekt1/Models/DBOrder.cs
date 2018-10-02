using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<OrderHelper> AllOrderInfo(int id)
        {

            using (var db = new DB())
            {
                var Orderlist = db.Order.Where(o=>o.User.Id == id);
                if (Orderlist == null) {
                    return null;
                }
                List<OrderHelper> AllOrderInfo = Orderlist.Select(k => new OrderHelper
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

        public List<OrderlineHelper> GetOrderInfo(int id,int userid)
        {
            using (var db = new DB()) {
                var UserOrder = db.Order.FirstOrDefault(o=>o.Id==id && o.User.Id==userid);

                if (UserOrder != null)
                {

                    var oneOrder = db.Orderline.Where(k => k.Order.Id == id);
                    if (oneOrder == null)
                    {
                        return null;
                    }

                    List<OrderlineHelper> OrderlineDetail = oneOrder.Select(k => new OrderlineHelper
                    {
                        Id = k.Id,
                        MovieId = k.Movie.Id,
                        Title = k.Movie.Title,
                        Category = k.Movie.Category,
                        Cost = k.Movie.Cost,
                        ImagePath = k.Movie.ImagePath

                    }).ToList();

                    return OrderlineDetail;

                }
                return null;
            }
        }
    }
}