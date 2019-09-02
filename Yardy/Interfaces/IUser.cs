using System.Collections.Generic;

namespace Yardy.Models
{
    public interface IUser
    {
        bool InsertUser(User user);
        bool CheckUserExists(string username);
        bool DeleteUser(int id);
        bool UpdateUser(User user);
        User GetUserByID(int id);
        bool AuthenticateUser(string username, string pw);
        User GetUserInfo(string username);

        //List or IEnumerable????
        List<User> GetAllUsers();
        IEnumerable<User> GetUsers();

    }
}