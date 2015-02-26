using BLL.Implements;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace UniversityWeb.Controllers
{
    public class GroupsController : Controller
    {
        public IGroupManager mgr;

        public GroupsController()
        {
            mgr = new GroupManager(new UnitOfWork());
        }

        // GET: Groups
        public ActionResult Index()
        {
            var groups = mgr.GetGroups();
            return View(groups);
        }
    }
}