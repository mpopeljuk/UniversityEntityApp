using BLL.DTO;
using BLL.Implements;
using BLL.Interfaces;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UniversityAPI.Controllers
{
    public class GroupsController : ApiController
    {
        private IGroupManager groupManager;

        public GroupsController()
        {
            UnitOfWork uOW = new UnitOfWork();

            groupManager = new GroupManager(uOW);
        }

        [HttpGet]
        public IEnumerable<GroupDTO> GetGroups()
        {
            IEnumerable<GroupDTO> list = null;
            try
            {
                list = groupManager.GetGroups();
            }
            catch (Exception)
            {
                this.ActionContext.Response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return list;
        }

        [HttpPut]
        public bool InsertGroup(Group group)
        {
            try
            {
                groupManager.InsertGroup(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteGroup(int id)
        {
            try
            {
                groupManager.DeleteGroup(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public bool UpdateGroup(Group group)
        {
            try
            {
                groupManager.UpdateGroup(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
