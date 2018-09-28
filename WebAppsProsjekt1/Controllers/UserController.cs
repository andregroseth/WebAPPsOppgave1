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
        //private DB db = new Models.DB();

        //GET: User/Login
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User loginAttempt)
        {
            if(FindUser(loginAttempt))
            {
                Session["Login"] = loginAttempt.Id;
                return RedirectToAction("ListMovie", "Movie");
            } else
            {
                return UserLogin();
            }
        }
        
        public void UserLogout()
        {
            if (Session["Login"] != null)
            {
                Session.Clear();
                Response.Redirect("UserLogin");
            } else
            {
                Response.Redirect("/Movie/ListMovie");
            }
        }

        private bool FindUser(User user)
        {
            using (var db = new DB())
            {
                User verifiedUser = db.User.FirstOrDefault(b => b.Email == user.Email);
                if (verifiedUser != null)
                {
                    string password = user.Password;
                    if (password != null)
                    {
                        bool verifiedPassword = verifiedUser.Password.SequenceEqual(password);
                        return verifiedPassword;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        //GET: User/RegisterUser
        public ActionResult RegisterUser()
        {
            return View();
            
        }

        //GET: User/ListUser
        public ActionResult ListUser()
        {
            using (var db = new DB())
            {
                List<Models.User> allUsers = db.User.ToList();
                return View(allUsers);
            }
        }

        [HttpPost]
        public ActionResult NewUser(Models.User inUser)
        {
            using (var db = new DB())
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
            using (var db = new DB())
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
            }
            return RedirectToAction ("ListUser");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}