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
    public class OrderBLL : BLL.IOrderBLL
    {
        private IDBOrder db;
        public OrderBLL()
        {
            db = new DBOrder();
        }

        public OrderBLL(IDBOrder stub)
        {
            db = stub;
        }
        public List<VMOrder> AllOrderInfo(int id)
        {
            return db.AllOrderInfo(id);
        }
        public bool DeleteOrder(int Id)
        {
            return db.DeleteOrder(Id);
        }
        public List<VMOrderline> GetOrderInfo(int id, int userid)
        {
            return db.GetOrderInfo(id, userid);
        }
    }
}
