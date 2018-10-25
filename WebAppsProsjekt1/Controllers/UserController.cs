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
        public ActionResult UserLogin(User partialUser)
        {
            if(db.UserFind(partialUser))
            {
                User user = db.GetUserInfo(partialUser.Email);
                Session["Login"] = db.GetSession(user).ToString();
				Session["LoginSuccess"] = "true";
                Session.Remove("LoginFailed");
                Session["Userlevel"] = user.Userlevel;
                return RedirectToAction("Movielist", "Movie");
            } else
            {
                Session["LoginFailed"] = "true";
            }
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
        public ActionResult UserDetail()
        {
            try
            {
                int.TryParse(Session["Login"].ToString(), out int userId);
                VMUser oneUser = db.GetVMUserInfo(userId);
                return View(oneUser);
            }
            catch
            {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin");
            }
        }
        //GET: User/UserRegister
        public ActionResult UserRegister()
        {
            return View();
        }

        //GET: User/UserList

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
        public ActionResult UserList()
        {
              List<VMUser> allUsers = db.AllUserInfo();
              return View(allUsers);
        }

        public ActionResult UserDelete(int id)
        {
            try
            {
                int.TryParse(Session["Userlevel"].ToString(), out int userlevel);
                if (userlevel > 0)
                {
                    db.DeleteUser(id);
                    return RedirectToAction("UserList"); ;
                }
                else
                {
                    Session["AccessFailedAdmin"] = "true";
                    return RedirectToAction("MovieList", "Movie");
                }
            }
            catch {
                Session["AccessFailedLogin"] = "true";
                return RedirectToAction("UserLogin");
            }
        }

        public ActionResult UserDetailAdminView(int id) {
            var oneUser = db.GetVMUserInfo(id);
            return View(oneUser);
        }

        public ActionResult UserEdit(int id)
        {
            VMUser oneUser = db.GetVMUserInfo(id);
            return View(oneUser);
        }

        [HttpPost]
        public ActionResult UserEdit(int id, VMUser edituser) {
            bool EditOk = db.EditUser(id,edituser);
            if (EditOk) {
                return RedirectToAction("UserList");
            }
            return View();
        }

        //Sjekker om Email eksistere fra før.
        //public JsonResult CheckEmail(string Email)
        //{
        //    return Json(!db.CheckEmail(Email), JsonRequestBehavior.AllowGet);
            
        //}
    }
}