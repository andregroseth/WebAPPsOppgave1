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
        private DB db = new Models.DB();

        // GET: Customer/RegisterCustomer
        public ActionResult RegisterCustomer()
        {
            return View();
            
        }

        //GET: Customer/ListCustomer
        public ActionResult ListCustomer()
        {
            List<Models.Customer> allCustomers = db.Customer.ToList();
            return View(allCustomers);
        }

        [HttpPost]
        public ActionResult NewCustomer(Models.Customer inCustomer)
        {
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
            return RedirectToAction("ListCustomer");
        }
      

        public ActionResult DeleteCustomer(int Id)
        {
            try
            {
                Models.Customer deleteCustomer = db.Customer.Find(Id);
                db.Customer.Remove(deleteCustomer);
                db.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction ("ListCustomer");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}