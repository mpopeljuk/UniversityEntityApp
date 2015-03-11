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
        private HttpResponseMessage response;

        public GroupsController()
        {
            UnitOfWork uOW = new UnitOfWork();

            groupManager = new GroupManager(uOW);
            studentManager = new StudentManager(uOW);
            response = new HttpResponseMessage();
        }

        [HttpGet]
        public HttpResponseMessage GetGroups()
        {
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
        public HttpResponseMessage UpdateGroup(Group group)
        {
            try
            {
                groupManager.UpdateGroup(group);

                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                return response;
            }
        }
        

        [HttpDelete]
        public HttpResponseMessage DeleteGroup(int id)
        {
            try
            {
                groupManager.DeleteGroup(id);

                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage InsertGroup(Group group)
        {
            try
            {
                groupManager.InsertGroup(group);

                response.StatusCode = HttpStatusCode.OK;
                return response; 
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                return response;
            }
        }
    }
}
