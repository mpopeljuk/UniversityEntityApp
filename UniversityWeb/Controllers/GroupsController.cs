using BLL.Implements;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DBModels;
using System.Net;

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
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Group group)
        {
            mgr.InsertGroup(group);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            int groupId = id ?? -1;
            var group = mgr.GetRawGroupByID(groupId);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mgr.DeleteGroup(id);
            return RedirectToAction("Index");
        }
    }
}