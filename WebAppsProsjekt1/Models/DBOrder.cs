using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DBOrder
    {
        public void AddOrdrer(List<Movie> inMovie, int id) {


            using ( var db=new DB()){

                var GetUser = db.User.FirstOrDefault(u => u.Id == id);

                var NewOrder = new Order()
                {
                    Date = DateTime.Today.ToString(),
                    User=GetUser
                };

                foreach (var movie in inMovie) {

                    var NewOrderline = new Orderline()
                    {
                        Order=NewOrder,
                        Movie=movie

                    };




                }
                

            }

               

        }





    }
}