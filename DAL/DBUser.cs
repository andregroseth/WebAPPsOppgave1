using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.DAL
{
    public class DBUser : DAL.IDBUser
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
                    Userlevel = k.Userlevel,
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
                Userlevel = InUser.Userlevel,
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
                    var CheckEmail = db.User.FirstOrDefault(u => u.Email == InUser.Email);
                    if (CheckEmail != null) {
                        return false;
                    }
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
                    NewUserRad.Email = InUser.Email;
                    db.User.Add(NewUserRad);
					DBLogger logger = new DBLogger();
					db.addExtrasToEntries(db.ChangeTracker);
					logger.logChanges(db);
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
					DBLogger logger = new DBLogger();
					db.addExtrasToEntries(db.ChangeTracker);
					logger.logChanges(db);
					db.SaveChanges();
                    return true;
                }
                catch (Exception error) { return false; }
            }
        }

        public VMUser GetVMUserInfo(int id)
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
                        Userlevel = oneUser.Userlevel,
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

        public User GetUserInfo(string email)
        {
            using (var db = new DB())
            {
                var user = db.User.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return null;
                }
                else
                {
                    var userOutput = new User()
                    {
                        Id = user.Id,
                        Userlevel = user.Userlevel,
                        Email = user.Email,
                        Firstname = user.Firstname,
                        Surname = user.Surname,
                        Password = user.Password,
                        Address = user.Address,
                        Mail = user.Mail,
                    };
                    System.Diagnostics.Debug.WriteLine("Fra DB: " + userOutput.Email);

                    return userOutput;
                }
            }
        }

        public bool EditUser(int id, VMUser inUser) {
           
            var db = new DB();
            try {
                User find = db.User.Find(id);
                find.Userlevel = inUser.Userlevel;
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
				DBLogger logger = new DBLogger();
				db.addExtrasToEntries(db.ChangeTracker);
				logger.logChanges(db);
				db.SaveChanges();
				return true;
            }
            catch {
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