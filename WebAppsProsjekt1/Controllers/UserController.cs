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
        public ActionResult UserLogin(User user)
        {
            var db = new DBUser();
            if(db.UserFind(user))
            {
                Session["Login"] = db.GetSession(user).ToString();
				Session["LoginSuccess"] = "true";
                Session.Remove("LoginFailed");
                if (db.checkIfAdmin() == true) {
                    Session["IfAdmin"] = "true";
                    return RedirectToAction("Movielist", "Movie");
                }
                return RedirectToAction("Movielist", "Movie");
            }
            Session["LoginFailed"] = "true";
            return View();
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

        //GET: User/UserRegister
        public ActionResult UserRegister()
        {
            return View();
        }

        //GET: User/UserList
        public ActionResult UserList()
        {
            var db = new DBUser();
			if(Session["Login"] == null) {
				Session["AccessFailedLogin"] = "true";
				return RedirectToAction("UserLogin");
			}
			if (db.checkIfAdmin() == true) {
                List<UserHelper> allUsers = db.AllUserInfo();
                return View(allUsers);
            }
            Session["AccessFailedAdmin"] = "true";
			return RedirectToAction("MovieList", "Movie");
        }

        [HttpPost]
        public ActionResult UserRegister(UserHelper inUser)
        {
            if (ModelState.IsValid)
            {
                var db = new DBUser();
                bool OK = db.SaveUserToDB(inUser);
                if (OK)
                {
					Session["RegistrationSuccess"] = true;
                    return RedirectToAction("UserLogin");
                }
            }
            return View();
        }

        public ActionResult UserDelete(int Id)
        {
            var db = new DBUser();
            if (db.checkIfAdmin() == true)
            {
                bool OK = db.DeleteUser(Id);
                if (OK)
                {
                    return RedirectToAction("UserList");
                }
                return View();
            }
            Session["AccessFailedAdmin"] = "true";
            return RedirectToAction("MovieList", "Movie");
        }

        public ActionResult UserDetail()
        {
            try
            {
                System.Diagnostics.Debug.Print(Session["Login"].ToString());
                var db = new DBUser();
                int.TryParse(Session["Login"].ToString(), out int userId);
                UserHelper oneUser = db.GetUserInfo(userId);
                return View(oneUser);
            }
            catch
            {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult UserDetailAdminView(int id) {
            var db = new DBUser();
            try
            {
                if (db.checkIfAdmin() == true)
                {          
                    var oneUser = db.GetUserInfo(id);
                    return View(oneUser);
                }
                Session["AccessFailedAdmin"] = "true";
                return RedirectToAction("MovieList", "Movie");
            }
            catch {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin");
            }
        }

        //Sjekker om Email eksistere fra før.
        public JsonResult CheckEmail(string Email)
        {
            using (var db = new DB())
            {
               return Json(!db.User.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
            }
        }

    }
}