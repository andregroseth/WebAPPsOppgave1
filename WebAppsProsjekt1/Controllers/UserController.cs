using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.Controllers
{
    public class UserController : Controller
    {
        private DB db = new Models.DB();

        //GET: User/Login
        public ActionResult UserLogin()
        {
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            List<Models.User> allUsers = db.User.ToList();
            foreach(var user in allUsers)
            {
                if (user.Email == email)
                {
                    if (user.Password == password)
                    {
                        Session[email] = user.Id;
                        FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                        return RedirectToAction("ListMovie");
                    }
                }
            }
            return View();
        }

        //GET: User/RegisterUser
        public ActionResult RegisterUser()
        {
            return View();
            
        }

        //GET: User/ListUser
        public ActionResult ListUser()
        {
            List<Models.User> allUsers = db.User.ToList();
            return View(allUsers);
        }

        [HttpPost]
        public ActionResult NewUser(Models.User inUser)
        {
            {
                try
                {
                    db.User.Add(inUser);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }
            }
            return RedirectToAction("ListUser");
        }
      

        public ActionResult DeleteUser(int Id)
        {
            try
            {
                Models.User deleteUser = db.User.Find(Id);
                db.User.Remove(deleteUser);
                db.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction ("ListUser");
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