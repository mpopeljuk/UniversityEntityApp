using BLL.Implements;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DBModels;

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

        [HttpGet]
        public ActionResult AddGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGroup(Group group)
        {
            mgr.InsertGroup(group);
            return RedirectToAction("Index");
        }
    }
}