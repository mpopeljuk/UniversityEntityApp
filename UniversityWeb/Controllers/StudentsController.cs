using BLL.Implements;
using BLL.Interfaces;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWeb.Models.Students;

namespace UniversityWeb.Controllers
{
    public class StudentsController : Controller
    {
        IStudentManager studentManager;
        IGroupManager groupManager;

        public StudentsController()
        {
            studentManager = new StudentManager(new UnitOfWork());
            groupManager = new GroupManager(new UnitOfWork());
        }

        public ActionResult Index()
        {
            var model = studentManager.GetStudents();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            StudentAddModel model = new StudentAddModel { Groups = groupManager.GetGroups() };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            studentManager.InsertStudent(student);
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
            var model = studentManager.GetRawStudentByID(studentId);
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
            studentManager.DeleteStudent(id);
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
            var student = studentManager.GetRawStudentByID(studentId);
            if (student == null)
            {
                return HttpNotFound();
            }
            var model = new StudentEditModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                GroupId = student.GroupId,
                Groups = groupManager.GetGroups()
            };
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            studentManager.UpdateStudent(student);
            return RedirectToAction("Index");
        }
    }
}