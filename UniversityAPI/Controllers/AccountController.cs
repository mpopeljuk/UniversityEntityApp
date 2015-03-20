using BLL.Implements;
using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UniversityAPI.Controllers
{
    public class AccountController : ApiController
    {
        UnitOfWork uOW;
        IUserManager userMngr;
        IRoleManager roleMngr;

        public AccountController()
        {
            uOW = new UnitOfWork();
            userMngr = new UserManager(uOW);
            roleMngr = new RoleManager(uOW);
        }


    }
}
