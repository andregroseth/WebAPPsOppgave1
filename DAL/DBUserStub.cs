using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.DAL
{
    public class DBUserStub : DAL.IDBUser
    {
        public int GetSession(User user)
        {
            int loginSession;
            using (var db = new DB())
            {
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
            var expectedResult = new List<VMUser>();
            var user = new VMUser()
            {
                Id = 1,
                Userlevel = 1,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };
            expectedResult.Add(user);
            expectedResult.Add(user);
            expectedResult.Add(user);

            return expectedResult;
        }

        public bool SaveUserToDB(VMUser InUser)
        {
            var NewUserRad = new User()
            {
                Userlevel = InUser.Userlevel,
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
            if (id != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public VMUser GetVMUserInfo(int id)
        {
            if (id == 0)
            {
                var user = new VMUser();
                user.Id = 0;
                return user;
            }
            else
            {
                var user = new VMUser()
                {
                    Id = 1,
                    Userlevel = 0,
                    Email = "trude@oslomet.no",
                    Firstname = "Trude",
                    Surname = "Solberg",
                    Password = "test",
                    Address = "Frognerveien 24B",
                    ZipCode = "9999",
                    Area = "test"
                };
                return user;
            }
        }

        public User GetUserInfo(string email)
        {
            using (var db = new DB())
            {
                var oneUser = db.User.Find(email);
                if (oneUser == null)
                {
                    return null;
                }
                else
                {
                    var oneUserOutput = new User()
                    {
                        Id = oneUser.Id,
                        Userlevel = oneUser.Userlevel,
                        Email = oneUser.Email,
                        Firstname = oneUser.Firstname,
                        Surname = oneUser.Surname,
                        Password = oneUser.Password,
                        Address = oneUser.Address,
                        Mail = oneUser.Mail,
                    };
                    return oneUserOutput;
                }
            }
        }

        public bool EditUser(int id, VMUser inUser)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string getHash(string password)
        {
            byte[] unhashed, hashed;
            var algorithm = System.Security.Cryptography.SHA256.Create();
            unhashed = System.Text.Encoding.ASCII.GetBytes(password);
            hashed = algorithm.ComputeHash(unhashed);
            return System.Text.Encoding.UTF8.GetString(hashed);
        }

        public bool CheckEmail(string Email)
        {
            using (var db = new DB())
            {
                if (db.User.Any(x => x.Email == Email))
                {

                    return true;
                }
                return false;
            }
        }

    }
}