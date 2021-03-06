﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebAppsProsjekt1.BLL;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.Controllers
{
    public class OrderController : Controller
    {

        private IOrderBLL db;

        public OrderController()
        {
            db = new OrderBLL();
        }

        public OrderController(IOrderBLL stub)
        {
            db = stub;
        }
        public ActionResult OrderList()
        {
            try
            {
                int.TryParse(Session["Login"].ToString(), out int userId);
                var allOrder = db.AllOrderInfo(userId);
                return View(allOrder);
            } catch
            {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin", "User");
            }
        }

        public ActionResult OrderDelete(int Id)
        {
            var db = new OrderBLL();
            if (db.DeleteOrder(Id))
            {
                return RedirectToAction("OrderList");
            }
			Session["DeleteFailed"] = "true";
			return View();
        }

        public ActionResult OrderDetail(int id)
        {
            if (Session["Login"] != null)
            {
                int.TryParse(Session["Login"].ToString(), out int userId);
                List<VMOrderline> ShowOrder = db.GetOrderInfo(id, userId);
                if (ShowOrder == null) {
                    Session["AccessUnauthorized"] = "true";
                    return RedirectToAction("OrderList");
                }
                return View(ShowOrder);
            }
            Session["AccessFailedLogin"] = "true";
            return RedirectToAction("UserLogin","User");
        }
        public ActionResult OrderListAdminView(int userId) {
            var allOrder = db.AllOrderInfo(userId);
            return View(allOrder);
        }

        public ActionResult OrderDetailAdminView(int id, int userId) {
            List<VMOrderline> ShowOrder = db.GetOrderInfo(id, userId);
            return View(ShowOrder);
        }
    }
}