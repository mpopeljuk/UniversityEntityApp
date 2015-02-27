using BLL.Implements;
using BLL.Interfaces;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityWeb.Controllers
{
    public class SubjectsController : Controller
    {
        ISubjectManager mgr;

        public SubjectsController()
        {
            mgr = new SubjectManager(new UnitOfWork());
        }

        public ActionResult Index()
        {
            var model = mgr.GetSubjects();
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
            mgr.InsertSubject(subject);
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
            var model = mgr.GetRawSubjectByID(subjectId);
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
            mgr.DeleteSubject(id);
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
            var model = mgr.GetRawSubjectByID(subjectId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Subject subject)
        {
            mgr.UpdateSubject(subject);
            return RedirectToAction("Index");
        }
    }
}