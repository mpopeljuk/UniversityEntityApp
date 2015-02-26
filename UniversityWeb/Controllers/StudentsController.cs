using BLL.Implements;
using BLL.Interfaces;
using DAL;
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
    }
}