using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.Controllers
{
    public class UserController : Controller
    {
        private DB db = new Models.DB();

        // GET: Customer/RegisterCustomer
        public ActionResult RegisterUser()
        {
            return View();
            
        }

        //GET: Customer/ListUser
        public ActionResult ListUser()
        {
            var db = new DBUser();
            List<HelperTable> allUsers = db.AllUserInfo();
            return View(allUsers);
        }

        [HttpPost]
        public ActionResult RegisterUser(HelperTable inUser)
        {
            if (ModelState.IsValid)
            {
                var db = new DBUser();
                bool OK = db.SaveUserToDB(inUser);
                if (OK)
                {
                    return RedirectToAction("ListUser");
                }
            }
            return View();
        }
      

        public ActionResult DeleteUser(int Id)
        {
            var db = new DBUser();
            bool OK = db.DeleteUser(Id);
            if (OK)
            {
                return RedirectToAction("ListUser");
            }
            return View();
        }

        public ActionResult UserDetail(int id) {
            var db = new DBUser();
            HelperTable oneUser = db.GetUserInfo(id);
            return View(oneUser);
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