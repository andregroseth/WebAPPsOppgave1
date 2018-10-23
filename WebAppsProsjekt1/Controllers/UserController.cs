using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppsProsjekt1.Model;
using WebAppsProsjekt1.BLL;

namespace WebAppsProsjekt1.Controllers
{
    public class UserController : Controller
    {
        //private DB db = new Models.DB();

        //GET: User/Login
        private IUserBLL db;

        public UserController() {
            db = new UserBLL();
        }

        public UserController(IUserBLL stub) {
            db = stub;
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User user)
        {
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
			if(Session["Login"] == null) {
				Session["AccessFailedLogin"] = "true";
				return RedirectToAction("UserLogin");
			}
			if (db.checkIfAdmin() == true) {
                List<VMUser> allUsers = db.AllUserInfo();
                return View(allUsers);
            }
            Session["AccessFailedAdmin"] = "true";
			return RedirectToAction("MovieList", "Movie");
        }

        [HttpPost]
        public ActionResult UserRegister(VMUser inUser)
        {
            if (ModelState.IsValid)
            {
                bool OK = db.SaveUserToDB(inUser);
                if (OK)
                {
					Session["RegistrationSuccess"] = true;
                    return RedirectToAction("UserLogin");
                }
            }
            return View();
        }

        public ActionResult UserDelete(int id)
        {
            if (db.checkIfAdmin() == true)
            {
                bool OK = db.DeleteUser(id);
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
                int.TryParse(Session["Login"].ToString(), out int userId);
                VMUser oneUser = db.GetUserInfo(userId);
                return View(oneUser);
            }
            catch
            {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult UserDetailAdminView(int id) {
            try
            {
                if (Session["IfAdmin"] != null)
                {
                    var oneUser = db.GetUserInfo(id);
                    return View(oneUser);
                }
                    Session["AccessFailedAdmin"] = "true";
                    return RedirectToAction("MovieList", "Movie");
            }catch {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult UserEdit(int id)
        {
            if (Session["Login"] == null)
            {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin");
            }
            if (db.checkIfAdmin() == true)
            {
                VMUser oneUser= db.GetUserInfo(id);
                VMAdmin newOneUser = db.GetUserInfoEdit(oneUser);
                return View(newOneUser);
            }
            Session["AccessFailedAdmin"] = "true";
            return RedirectToAction("MovieList", "Movie");
        }
        [HttpPost]
        public ActionResult UserEdit(int id, VMAdmin edituser) {
            if (ModelState.IsValid) {
                bool EditOk = db.EditUser(id,edituser);
                if (EditOk) {
                    return RedirectToAction("UserList");
                }
            }
            return View();
        }
        //Sjekker om Email eksistere fra før.
        public JsonResult CheckEmail(string Email)
        {
               return Json(!db.CheckEmail(Email), JsonRequestBehavior.AllowGet);
            
        }

    }
}