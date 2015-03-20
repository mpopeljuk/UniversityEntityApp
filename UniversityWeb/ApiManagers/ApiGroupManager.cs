using DBModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWeb.Helpers;

namespace UniversityWeb.ApiManagers
{
    public class ApiGroupManager
    {
        public List<GroupDTO> GetGroups()
        {
            var result = RequestHelper.Get<List<GroupDTO>>("Groups");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return result.Data;
            }
            else
            {
                return null;
            }
        }
    }
}