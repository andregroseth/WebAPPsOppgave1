using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppsProsjekt1.DAL;
using WebAppsProsjekt1.Model;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.BLL
{
    public class UserBLL
    {
        public int GetSession(User user)
        {
            var db = new DBUser();
            return db.GetSession(user);
        }
        public bool UserFind(User user)
        {
            var db = new DBUser();
            return db.UserFind(user);
        }

        public List<VMUser> AllUserInfo()
        {
            var db = new DBUser();
            List<VMUser> AllUserInfo = db.AllUserInfo();
            return AllUserInfo;
        }

        public bool SaveUserToDB(VMUser InUser)
        {
        var db = new DBUser();
        return db.SaveUserToDB(InUser);

        }

        public bool DeleteUser(int id)
        {
        var db = new DBUser();
        return db.DeleteUser(id);
        }


        public VMUser GetUserInfo(int id)
        {
        var db = new DBUser();
        return db.GetUserInfo(id);
    }
        public VMAdmin GetUserInfoEdit(VMUser Helper)
        {
        var db = new DBUser();
        return db.GetUserInfoEdit(Helper);
    }

        public bool EditUser(int id, VMAdmin inUser)
        {
        var db = new DBUser();
        return db.EditUser(id,inUser);
        }

        public bool checkIfAdmin()
        {
        var db = new DBUser();
        return db.checkIfAdmin();
        }

        public string getHash(string password)
        {
            var db = new DBUser();
            return db.getHash(password);
        }
        public bool CheckEmail(string Email)
        {
            var db = new DBUser();
            return db.CheckEmail(Email);
        }

    }
}
