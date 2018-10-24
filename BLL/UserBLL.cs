using System.Collections.Generic;
using WebAppsProsjekt1.DAL;
using WebAppsProsjekt1.Model;

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

        public VMUser GetVMUserInfo(int id)
        {
            return db.GetVMUserInfo(id);
        }

        public User GetUserInfo(string email)
        {
            return db.GetUserInfo(email);
        }

        public bool EditUser(int id, VMUser inUser)
        {
            return db.EditUser(id,inUser);
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
