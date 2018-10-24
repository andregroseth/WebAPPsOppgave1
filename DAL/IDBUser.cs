using System.Collections.Generic;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.DAL
{
    public interface IDBUser
    {
        List<VMUser> AllUserInfo();
        bool CheckEmail(string Email);
        bool DeleteUser(int id);
        bool EditUser(int id, VMUser inUser);
        string getHash(string password);
        int GetSession(User user);
        VMUser GetVMUserInfo(int id);
        User GetUserInfo(string email);
        bool SaveUserToDB(VMUser InUser);
        bool UserFind(User user);
    }
}