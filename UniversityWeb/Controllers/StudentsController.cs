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
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            mgr.InsertStudent(student);
            return RedirectToAction("Index");
        }
    }
}