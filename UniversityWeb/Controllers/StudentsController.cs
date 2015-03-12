﻿using BLL.Implements;
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

        public StudentsController(IStudentManager studentManager, IGroupManager groupManager)
        {
            this.studentManager = studentManager;
            this.groupManager = groupManager;
        }

        public ActionResult Index()
        {
            HttpContext.Session["asd"] = 2;
            //var model = studentManager.GetStudents();

            //new tasks = new models)
            var model = new StudentIndexModel
            {
                Students = studentManager.GetStudents(),
                Groups = groupManager.GetGroups()
            };
            
            return View(model);
        }

        

        [HttpGet]
        public ActionResult GetStudent(int? id)
        {
            var model = studentManager.GetStudentByID(id.Value);
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new StudentAddEditModel { Groups = groupManager.GetGroups() };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            studentManager.InsertStudent(student);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult SAddData(string a)
        {
            var m = new Student() { FirstName = "Bogdan" };
            return Json(m, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SGetStudent()
        {
            var m = new Student() { FirstName = "Bogdan" };
            return Json(m, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudentsTable()
        {
            var model = studentManager.GetStudents();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AjaxAdd(Student student)
        {
            studentManager.InsertStudent(student);
            //returning all data, but we can return only 1 row
            //which is a studentDTO
            return RedirectToAction("GetStudentsTable");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            int studentId = id.Value;
            var model = studentManager.GetStudentByID(studentId);
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
            var model = new StudentAddEditModel
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