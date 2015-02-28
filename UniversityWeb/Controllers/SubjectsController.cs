﻿using BLL.Implements;
using BLL.Interfaces;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWeb.Models.Subjects;

namespace UniversityWeb.Controllers
{
    public class SubjectsController : Controller
    {
        ISubjectManager subjectManager;
        IGroupToSubjectManager gtsManager;

        public SubjectsController()
        {
            subjectManager = new SubjectManager(new UnitOfWork());
            gtsManager = new GroupToSubjectManager(new UnitOfWork());
        }

        public ActionResult Index()
        {
            var model = subjectManager.GetSubjects();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Subject subject)
        {
            subjectManager.InsertSubject(subject);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int subjectId = id.Value;
            var model = subjectManager.GetRawSubjectByID(subjectId);
            if (model == null)
            {
                HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subjectManager.DeleteSubject(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int subjectId = id.Value;
            var model = subjectManager.GetRawSubjectByID(subjectId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Subject subject)
        {
            subjectManager.UpdateSubject(subject);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int subjectId = id.Value;
            Subject group = subjectManager.GetRawSubjectByID(subjectId);
            var groupList = gtsManager.GetGroupsForSubject(subjectId);
            SubjectDetailModel model = new SubjectDetailModel
            {
                Id = group.Id,
                Name = group.Name,
                Groups = groupList
            };
            return View(model);
        }
    }
}