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
                return RedirectToAction("MovieList", "Movie");
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
                Response.Redirect("/Movie/MovieList");
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
        public ActionResult UserRegister()
        {
            return View();
            
        }

        //GET: User/ListUser
        public ActionResult UserList()
        {
            var db = new DBUser();
            List<HelperTable> allUsers = db.AllUserInfo();
            return View(allUsers);
        }

        [HttpPost]
        public ActionResult UserRegister(HelperTable inUser)
        {
            if (ModelState.IsValid)
            {
                var db = new DBUser();
                bool OK = db.SaveUserToDB(inUser);
                if (OK)
                {
                    return RedirectToAction("UserList");
                }
            }
            return View();
        }
      

        public ActionResult UserDelete(int Id)
        {
            var db = new DBUser();
            bool OK = db.DeleteUser(Id);
            if (OK)
            {
                return RedirectToAction("UserList");
            }
            return View();
        }

        public ActionResult UserDetail(int id)
        {
            var db = new DBUser();
            HelperTable oneUser = db.GetUserInfo(id);
            return View(oneUser);
        }


        //Sjekker om Email eksistere fra før.
        public JsonResult CheckEmail(string Email)
        {
            using (var db = new DB())
            {
                  
                return Json(!db.User.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
            }
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