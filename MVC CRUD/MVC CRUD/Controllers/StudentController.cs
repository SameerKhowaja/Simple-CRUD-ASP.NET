using Microsoft.Ajax.Utilities;
using MVC_CRUD.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class StudentController : Controller
    {
        DB_MVC_CRUD_ASPNET_TESTEntities dbObj = new DB_MVC_CRUD_ASPNET_TESTEntities();

        // GET: Student
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            if (ModelState.IsValid)
            {
                tbl_Student obj = new tbl_Student();
                obj.Name = model.Name;
                obj.Email = model.Email;
                obj.Fname = model.Fname;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;
                dbObj.tbl_Student.Add(obj);
                dbObj.SaveChanges();

                ModelState.Clear();
            }

            int newid = 0;
            return View("Student", new { newid });
        }

        public ActionResult StudentList()
        {
            var list = dbObj.tbl_Student.ToList();
            return View(list);
        }

        public ActionResult StudentDelete(int id)
        {
            var res = dbObj.tbl_Student.Where(x => x.ID == id).First();
            dbObj.tbl_Student.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tbl_Student.ToList();
            return View("StudentList", list);
        }
    }
}