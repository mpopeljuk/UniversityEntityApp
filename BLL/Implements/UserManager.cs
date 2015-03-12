using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implements
{
    public class UserManager : BaseManager, IUserManager
    {
        public UserManager(UnitOfWork uOW)
            : base(uOW)
        {
        }

        public IEnumerable<DBModels.User> GetUsers()
        {
            var list = uOW.UserRepo.Get();
            return list.ToList();
        }

        public DBModels.User GetUserByUserName(string login, string password)
        {
            var item = uOW.UserRepo.Get()
                .Where(s => s.UserName == login)
                .Where(s => s.Password == password).FirstOrDefault();

            if (item != null)
            {
                return item;
            }
            return null;
        }

        public DBModels.User GetUserByEmail(string email, string password)
        {
            var item = uOW.UserRepo.Get()
                .Where(s => s.Email == email)
                .Where(s => s.Password == password).FirstOrDefault();

            if (item != null)
            {
                return item;
            }
            return null;
        }

        public DBModels.User InsertUser(DBModels.User user)
        {
            uOW.UserRepo.Insert(user);
            uOW.Save();
            return user;
        }

        public void DeleteUser(int userId)
        {
            uOW.UserRepo.Delete(uOW.UserRepo.GetByID(userId));
            uOW.Save();
        }

        public DBModels.User UpdateUser(DBModels.User user)
        {
            uOW.UserRepo.Update(user);
            uOW.Save();
            return user;
        }
    }
}
