using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppsProsjekt1.DAL;
using WebAppsProsjekt1.Model;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.BLL
{
    public class OrderBLL
    {
        public List<VMOrder> AllOrderInfo(int id)
        {
            var db = new DBOrder();
            return db.AllOrderInfo(id);
        }
        public bool DeleteOrder(int Id)
        {
            var db = new DBOrder();
            return db.DeleteOrder(Id);
        }
        public List<VMOrderline> GetOrderInfo(int id, int userid)
        {
            var db = new DBOrder();
            return db.GetOrderInfo(id, userid);
        }
    }
}
