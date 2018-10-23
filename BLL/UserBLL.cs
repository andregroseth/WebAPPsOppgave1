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
    public class UserBLL : BLL.IUserBLL
    {
        private IDBUser db;
        public UserBLL() {
            db = new DBUser();
        }

        public UserBLL(IDBUser stub) {
            db = stub;
        }

        public int GetSession(User user)
        {
            return db.GetSession(user);
        }
        public bool UserFind(User user)
        {
            return db.UserFind(user);
        }

        public List<VMUser> AllUserInfo()
        {
            List<VMUser> AllUserInfo = db.AllUserInfo();
            return AllUserInfo;
        }

        public bool SaveUserToDB(VMUser InUser)
        {
            return db.SaveUserToDB(InUser);

        }

        public bool DeleteUser(int id)
        {
            return db.DeleteUser(id);
        }

        public VMUser GetUserInfo(int id)
        {
            return db.GetUserInfo(id);
        }
        public VMAdmin GetUserInfoEdit(VMUser Helper)
        {
            return db.GetUserInfoEdit(Helper);
        }

        public bool EditUser(int id, VMAdmin inUser)
        {
            return db.EditUser(id,inUser);
        }

        public bool checkIfAdmin()
        {
            return db.checkIfAdmin();
        }

        public string getHash(string password)
        {
            return db.getHash(password);
        }
        public bool CheckEmail(string Email)
        {
            return db.CheckEmail(Email);
        }

    }
}
