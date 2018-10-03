using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebAppsProsjekt1.Models;
namespace WebAppsProsjekt1.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult OrderList()
        {

            if (Session["Login"] != null)
            {

                var db = new DBOrder();
                int.TryParse(Session["Login"].ToString(), out int userId);
                var allOrder = db.AllOrderInfo(userId);
                return View(allOrder);

            }
            return RedirectToAction("UserLogin","User");

        }

        public ActionResult OrderDelete(int Id)
        {
            var db = new DBOrder();
            bool OK = db.DeleteOrder(Id);
            if (OK)
            {
                return RedirectToAction("OrderList");
            }
            return View();
        }

        public ActionResult OrderDetail(int id)
        {
            if (Session["Login"] != null)
            {
                var db = new DBOrder();
                int.TryParse(Session["Login"].ToString(), out int userId);
                List<OrderlineHelper> ShowOrder = db.GetOrderInfo(id, userId);

                return View(ShowOrder);
            }
            return RedirectToAction("UserLogin","User");
        }
    }
}