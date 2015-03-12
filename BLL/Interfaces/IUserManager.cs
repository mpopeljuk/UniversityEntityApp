using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserManager
    {
        IEnumerable<User> GetUsers();
        User GetUserByLogin(string login, string password);
        User GetUserByEmail(string email, string password);
        User InsertUser(User user);
        void DeleteUser(int userId);
        User UpdateUser(User user);
    }
}
