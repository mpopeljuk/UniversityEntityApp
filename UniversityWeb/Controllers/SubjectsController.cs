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
    }
}