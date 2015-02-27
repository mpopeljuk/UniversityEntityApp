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

        public ActionResult Index()
        {
            var model = mgr.GetGroups();
            return View(model);
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
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int groupId = id.Value;
            var model = mgr.GetRawGroupByID(groupId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mgr.DeleteGroup(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int groupId = id.Value;
            var model = mgr.GetRawGroupByID(groupId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                mgr.UpdateGroup(group);
                return RedirectToAction("Index");
            }
            return View(group);
        }
    }
}