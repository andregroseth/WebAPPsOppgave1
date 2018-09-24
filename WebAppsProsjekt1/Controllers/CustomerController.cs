using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/NewCustomer
        [HttpPost]
        public ActionResult NewCustomer(Models.Customer inCustomer)
        {
            //var newCustomer = new Customer{ Name = "Shrek" };
            //return View(newCustomer);
            using (var db = new Models.DB())
            {
                try
                {
                    db.Customer.Add(inCustomer);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }
            }
            return RedirectToAction("List");
        }
    }

    //public ActionResult CustomerList()
    //{
    //    using (var db = new Models.DB())
    //    {
    //        List<Models.Customer> allCustomers = db.Customer.ToList();
    //        return View(allCustomers);
    //    }
    //}
}