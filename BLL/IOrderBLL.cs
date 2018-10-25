using System.Collections.Generic;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.BLL
{
    public interface IOrderBLL
    {
        List<VMOrder> AllOrderInfo(int id);
        bool DeleteOrder(int Id);
        List<VMOrderline> GetOrderInfo(int id, int userid);
    }
}