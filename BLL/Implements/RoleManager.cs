using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implements
{
    public class RoleManager : BaseManager, IRoleManager
    {
        public RoleManager(UnitOfWork uOW)
            : base(uOW)
        {
        }

        public IEnumerable<DBModels.Role> GetRoles()
        {
            return uOW.RoleRepo.Get().ToList();
        }

        public DBModels.Role GetRoleById(int roleId)
        {
            return uOW.RoleRepo.GetByID(roleId);
        }

        public DBModels.Role InsertRole(DBModels.Role role)
        {
            uOW.RoleRepo.Insert(role);
            uOW.Save();
            return role;
        }

        public void DeleteRole(int roleId)
        {
            uOW.RoleRepo.Delete(uOW.RoleRepo.GetByID(roleId));
            uOW.Save();
        }

        public DBModels.Role UpdateRole(DBModels.Role role)
        {
            uOW.RoleRepo.Update(role);
            uOW.Save();
            return role;
        }
    }
}
