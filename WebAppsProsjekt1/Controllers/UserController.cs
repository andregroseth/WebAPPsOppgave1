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
                Session.Remove("LoginFailed");
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
            if (checkIfAdmin() == true) {
                var db = new DBUser();
                List<UserHelper> allUsers = db.AllUserInfo();
                return View(allUsers);
            }
            return RedirectToAction("UserLogin");
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


        public ActionResult UserDetail()
        {
            try
            {
                var db = new DBUser();
                int.TryParse(Session["Login"].ToString(), out int userId);
                UserHelper oneUser = db.GetUserInfo(userId);
                return View(oneUser);
            }
            catch {
                return RedirectToAction("UserLogin");
            }
        }

        public bool checkIfAdmin()
        {
            try
            {
                var db = new DBUser();
                int.TryParse(Session["Login"].ToString(), out int userId);
                UserHelper oneUser = db.GetUserInfo(userId);
                if (oneUser.Userlvl > 0)
                {
                    return true;
                }
                return false;
            }
            catch {
                return false;
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

        public ActionResult OrderList()
        {
            if(Session["Login"] != null){

                var db = new DBOrder();
                int.TryParse(Session["Login"].ToString(), out int userId);
                List<OrderHelper> allOrder = db.AllOrderInfo(userId);
                return View(allOrder);

            }
        
            return RedirectToAction("UserLogin");
        }
        public ActionResult OrderDelete(int Id)
        {
            var db = new DBOrder();
            bool OK = db.DeleteOrder(Id);
            if (OK)
            {
                return RedirectToAction("OrderList");
            }
            return View();
        }

        public ActionResult OrderDetail(int id)
        {
            if (Session["Login"] != null)
            {
                var db = new DBOrder();
                int.TryParse(Session["Login"].ToString(), out int userId);
                var ShowOrder = db.GetOrderInfo(id, userId);
                return View(ShowOrder);
            }
            return RedirectToAction("UserLogin");
        }
    }
}