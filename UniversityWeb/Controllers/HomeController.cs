using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWeb.ApiManagers;
using UniversityWeb.Helpers;

namespace UniversityWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var groupmng = new ApiGroupManager();
            var groups = groupmng.GetGroups();
            return View();
        }
    }
}