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
using BLL.DTO;
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

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Group group)
        {
            groupManager.InsertGroup(group);
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
            var model = groupManager.GetRawGroupByID(groupId);
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
            groupManager.DeleteGroup(id);
            return RedirectToAction("Index");
        }

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
            if(group == null)
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