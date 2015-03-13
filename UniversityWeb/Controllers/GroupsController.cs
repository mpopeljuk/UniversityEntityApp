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
using UniversityWeb.Models.Groups;

namespace UniversityWeb.Controllers
{
    public class GroupsController : Controller
    {
        public IGroupManager groupManager;
        public IGroupToSubjectManager gtsManager;
        public IStudentManager studentManager;

        public GroupsController(IGroupManager groupManager, IGroupToSubjectManager gtsManager,
                IStudentManager studentManager)
        {
            this.groupManager = groupManager;
            this.gtsManager = gtsManager;
            this.studentManager = studentManager;
        }

        public ActionResult Index()
        {
            var model = groupManager.GetGroups();
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(Group group)
        {
            groupManager.InsertGroup(group);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int groupId = id.Value;
            var model = groupManager.GetRawGroupByID(groupId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            groupManager.DeleteGroup(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int groupId = id.Value;
            var model = groupManager.GetRawGroupByID(groupId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        public JsonResult GetById(int? id)
        {
            return Json(groupManager.GetGroupByID(id.Value), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                groupManager.UpdateGroup(group);
                return RedirectToAction("Index");
            }
            return View(group);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int groupId = id.Value;
            Group group = groupManager.GetRawGroupByID(groupId);
            if (group == null)
            {
                return HttpNotFound();
            }
            var subjectList = gtsManager.GetSubjectsForGroup(groupId);
            var studentList = studentManager.GetStudentsByGroupId(groupId);
            GroupDetailModel model = new GroupDetailModel
            {
                Id = group.Id,
                Name = group.Name,
                Subjects = subjectList,
                Students = studentList
            };
            return View(model);
        }
    }
}