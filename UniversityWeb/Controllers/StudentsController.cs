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
    public class StudentsController : Controller
    {
        IStudentManager mgr;

        public StudentsController()
        {
            mgr = new StudentManager(new UnitOfWork());
        }

        public ActionResult Index()
        {
            var model = mgr.GetStudents();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            mgr.InsertStudent(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int studentId = id.Value;
            var model = mgr.GetRawStudentByID(studentId);
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
            mgr.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int studentId = id.Value;
            var model = mgr.GetRawStudentByID(studentId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            mgr.UpdateStudent(student);
            return RedirectToAction("Index");
        }
    }
}