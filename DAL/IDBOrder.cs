using System.Collections.Generic;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.DAL
{
    public interface IDBOrder
    {
        void AddOrder(List<Movie> inMovie, int id);
        List<VMOrder> AllOrderInfo(int id);
        bool DeleteOrder(int Id);
        List<VMOrderline> GetOrderInfo(int id, int userid);
    }
}