using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleManager
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int roleId);
        Role GetRoleByName(string name);
        Role InsertRole(Role role);
        void DeleteRole(int roleId);
        Role UpdateRole(Role role);
    }
}
