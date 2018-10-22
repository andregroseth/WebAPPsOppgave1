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
                var verifiedUser = db.User.FirstOrDefault(u => u.Email == user.Email);
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
                    string password = getHash(user.Password);
                    if (password != null)
                    {
                        bool verifiedPassword = verifiedUser.Password.SequenceEqual(password);
                        if (verifiedPassword)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public List<VMUser> AllUserInfo()
        {
            using (var db = new DB())
            {
                List<VMUser> AllUserInfo = db.User.Select(k => new VMUser
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

        public bool SaveUserToDB(VMUser InUser)
        {
            var NewUserRad = new User()
            {
                Userlvl = InUser.Userlvl,
                Email = InUser.Email,
                Firstname = InUser.Firstname,
                Surname = InUser.Surname,
                Password = getHash(InUser.Password),
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


        public VMUser GetUserInfo(int id)
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
                    var oneUserOutput = new VMUser()
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
                    return oneUserOutput;
                }
            }
        }
        public VMAdmin GetUserInfoEdit(VMUser Helper){
            VMAdmin editInfo = new VMAdmin()
            {
                Id=Helper.Id,
                Userlvl = Helper.Userlvl,
                Email = Helper.Email,
                Firstname = Helper.Firstname,
                Surname = Helper.Surname,
                Password = Helper.Password,
                ConfirmEmail=Helper.Email,
                Address = Helper.Address,
                ZipCode = Helper.ZipCode,
                Area = Helper.Area
            };
            return editInfo;
        }

        public bool EditUser(int id, VMAdmin inUser) {
            var db = new DB();
            try {
                User find = db.User.Find(id);
                find.Userlvl = inUser.Userlvl;
                find.Email = inUser.Email;
                find.Firstname = inUser.Firstname;
                find.Surname = inUser.Surname;
                find.Password = inUser.Password;
                find.Address = inUser.Address;
                Mail inUserMail = db.Mail.FirstOrDefault(m => m.ZipCode == inUser.ZipCode);
                if (inUserMail != null)
                {
                    if (find.Mail != inUserMail)
                    {
                        find.Mail = inUserMail;
                    }
                }
                else {
                    var newMail = new Mail() {
                        ZipCode = inUser.ZipCode,
                        Area = inUser.Area
                    };
                    find.Mail = newMail;
                }
                db.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        public bool checkIfAdmin()
        {
            try
            {
                int.TryParse(HttpContext.Current.Session["Login"].ToString(), out int userId);
                VMUser oneUser = GetUserInfo(userId);
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

		public string getHash(string password) {
			byte[] unhashed, hashed;
			var algorithm = System.Security.Cryptography.SHA256.Create();
			unhashed = System.Text.Encoding.ASCII.GetBytes(password);
			hashed = algorithm.ComputeHash(unhashed);
			return System.Text.Encoding.UTF8.GetString(hashed);
		}

    }
}