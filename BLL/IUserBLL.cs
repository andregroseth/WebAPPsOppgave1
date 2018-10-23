using System.Collections.Generic;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.BLL
{
    public interface IUserBLL
    {
        List<VMUser> AllUserInfo();
        bool CheckEmail(string Email);
        bool checkIfAdmin();
        bool DeleteUser(int id);
        bool EditUser(int id, VMAdmin inUser);
        string getHash(string password);
        int GetSession(User user);
        VMUser GetUserInfo(int id);
        VMAdmin GetUserInfoEdit(VMUser Helper);
        bool SaveUserToDB(VMUser InUser);
        bool UserFind(User user);
    }
}