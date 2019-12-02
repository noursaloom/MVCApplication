using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCApplication.Models;


namespace MyMVCApplication.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> studentList = new List<Student>{
                            new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                            new Student() { StudentId = 6, StudentName = "Chris" , Age = 17 } ,
                            new Student() { StudentId = 7, StudentName = "Rob" , Age = 19 }
                        };

        // GET: Student
        public ActionResult Index()
        {
        return View(studentList);
        }
        public ActionResult Edit(int? id) {
           var std = new Student();
            if (id != null)
            {
                 std = studentList.Where(slist => slist.StudentId == id).FirstOrDefault();
            }
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            if (std.StudentId != 0)
            {
                var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
                student.StudentName = std.StudentName;
                student.Age = std.Age;
                student.StudentId = std.StudentId;
            }
            else {
                std.StudentId = studentList.Max(x => x.StudentId) + 1;
                studentList.Add(std);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(std);
        }
        public ActionResult Delete(int id) {
           var std = studentList.Where(slist => slist.StudentId == id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Delete(Student std)
        {
            var studentRemove = studentList.FirstOrDefault(x => x.StudentId == std.StudentId);
            studentList.Remove(studentRemove);
            return RedirectToAction("Index");
        }
    }
}