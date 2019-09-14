using System.Collections.Generic;
using Yardy.Models;
using System.Linq;
using Yardy.ViewModels;

namespace Yardy
{

    //TODO: check active flags for users
    public class UserService : IUser
    {
        private readonly YardyDbContext context;

        public UserService(YardyDbContext context)
        {
            this.context = context;
        }

        public bool AuthenticateUser(string username, string pw)
        {
            var res = (from x in context.User where x.Username == username && x.Password == pw && x.Active == true select x).FirstOrDefault();

            if (res != null)
            {
                return true;
            }

            return false;

        }

        public bool CheckUserExists(string username)
        {
            return context.User.Count(x => x.Username == username) > 0;
        }

        public bool DeleteUser(int id)
        {
            var user = context.User.Where(x => x.UserId == id).FirstOrDefault();

            if (user != null)
            {
                user.Active = false;

                var res = context.SaveChanges();

                if (res > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public List<User> GetAllUsers()
        {
            return context.User.ToList();
        }

        public IEnumerable<User> GetUsers()
        {
            return context.User.ToList();
        }

        public User GetUserByID(int id)
        {
            return context.User.Where(x => x.UserId == id).FirstOrDefault();

        }


        //async insert???
        public bool InsertUser(User user)
        {
            if (user != null)
            {
                context.User.Add(user);
                var res = context.SaveChanges();

                if (res > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public bool UpdateUser(User user)
        {
            if (user != null)
            {
                context.Entry(user).Property(x => x.Username).IsModified = true;
                context.Entry(user).Property(x => x.Password).IsModified = true;

                var res = context.SaveChanges();

                if (res > 0)
                {
                    return true;
                }

                return false;
            }


            return false;
        }

        public LoginResponse GetUserInfo(string username, string pw)
        {

            //TODO: Join on user profile??

            try
            {
                var user = context.User.Where(x => x.Username == username && x.Password == pw).FirstOrDefault();

                if (user != null)
                {
                    LoginResponse loginResponse = new LoginResponse();

                    loginResponse.Username = user.Username;
                    loginResponse.UserId = user.UserId;
                    loginResponse.RoleId = context.UserRole.Where(x => x.UserId == user.UserId).FirstOrDefault().RoleId;
                    loginResponse.Status = user.Active;

                    return loginResponse;
                }

                return null;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}