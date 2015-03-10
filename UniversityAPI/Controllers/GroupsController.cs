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
        private IStudentManager studentManager;

        public GroupsController()
        {
            UnitOfWork uOW = new UnitOfWork();

            groupManager = new GroupManager(uOW);
            studentManager = new StudentManager(uOW);
        }

        [HttpGet]
        public HttpResponseMessage GetGroups()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            IEnumerable<GroupDTO> list;

            try
            {
                list = groupManager.GetGroups();
                response = Request.CreateResponse<IEnumerable<GroupDTO>>(
                        HttpStatusCode.OK, list);
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetGroupDetail(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            IEnumerable<Student> list;

            try
            {
                list = studentManager.GetStudentsByGroupId(id);
                response = Request.CreateResponse<IEnumerable<Student>>(
                        HttpStatusCode.OK, list);
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
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
