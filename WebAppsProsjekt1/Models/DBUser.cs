using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DBUser
    {
        public int GetSession(User user)
        {
            int loginSession;
            using (var db = new DB()) {
                var verifiedUser= db.User.FirstOrDefault(u =>u.Email == user.Email);
                loginSession = verifiedUser.Id;
            }
            return loginSession;
        }
        public bool UserFind(User user)
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
                        if(verifiedPassword)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public List<UserHelper> AllUserInfo()
        {
            using (var db = new DB())
            {

                List<UserHelper> AllUserInfo = db.User.Select(k => new UserHelper
                {

                    Id = k.Id,
                    Userlvl = k.Userlvl,
                    Email = k.Email,
                    Firstname = k.Firstname,
                    Surname = k.Surname,
                    Password = k.Password,
                    Address = k.Address,
                    ZipCode = k.Mail.ZipCode,
                    Area = k.Mail.Area
                }).ToList();

                return AllUserInfo;
            }

        }

        public bool SaveUserToDB(UserHelper InUser)
        {
            var NewUserRad = new User()
            {
                Userlvl = InUser.Userlvl,
                Email = InUser.Email,
                Firstname = InUser.Firstname,
                Surname = InUser.Surname,
                Password = InUser.Password,
                Address = InUser.Address
            };
            using (var db = new DB())
            {
                try
                {
                    var CheckZipcode = db.Mail.FirstOrDefault(m => m.ZipCode == InUser.ZipCode);
                    if (CheckZipcode == null)
                    {
                        var NewMailRad = new Mail()
                        {
                            ZipCode = InUser.ZipCode,
                            Area = InUser.Area
                        };
                        NewUserRad.Mail = NewMailRad;
                    }
                    else
                    {

                        NewUserRad.Mail = CheckZipcode;
                    }
                    db.User.Add(NewUserRad);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }

            }

        }

        public bool DeleteUser(int id)
        {
            using (var db = new DB())
            {
                try
                {
                    var DeleteUserRad = db.User.FirstOrDefault(u => u.Id == id);
                    var DeleteOrderRad = db.Order.Where(x => x.User.Id == DeleteUserRad.Id).ToList();
                    if (DeleteOrderRad != null)
                    {
                        System.Diagnostics.Debug.Write("AIHODASHDFNADK" + DeleteOrderRad);
                        foreach (var item in DeleteOrderRad)
                        {
                           
                            var DeleteOrderlineRad = db.Orderline.Where(a => a.Order.Id == item.Id);
                            foreach (var itemline in DeleteOrderlineRad)
                            {
                                db.Orderline.Remove(itemline);
                            }
                            db.Order.Remove(item);
                        }

                    }
                    db.User.Remove(DeleteUserRad);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception error) { return false; }
            }

        }


        public UserHelper GetUserInfo(int id)
        {
            using (var db = new DB())
            {
                var oneUser = db.User.Find(id);
                if (oneUser == null)
                {
                    return null;
                }
                else
                {
                    var oneUserOuptput = new UserHelper()
                    {
                        Id = oneUser.Id,
                        Userlvl = oneUser.Userlvl,
                        Email = oneUser.Email,
                        Firstname = oneUser.Firstname,
                        Surname = oneUser.Surname,
                        Password = oneUser.Password,
                        Address = oneUser.Address,
                        ZipCode = oneUser.Mail.ZipCode,
                        Area = oneUser.Mail.Area

                    };
                    return oneUserOuptput;
                }
            }
        }

        public bool checkIfAdmin()
        {
            try
            {
                int.TryParse(HttpContext.Current.Session["Login"].ToString(), out int userId);
                UserHelper oneUser = GetUserInfo(userId);
                if (oneUser.Userlvl > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}