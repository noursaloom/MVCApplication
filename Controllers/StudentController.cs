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
                            new Student() { StudentId = 1, StudentName = "John", Age = 18 ,MobileNumber="0787432071",StudentEmail="xx@gmail.com"} ,
                            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21,MobileNumber="0784523698",StudentEmail="xx@gmail.com"} ,
                            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 ,MobileNumber="0123698714",StudentEmail="xx@gmail.com"} ,
                            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20,MobileNumber="0778965412",StudentEmail="xx@gmail.com" } ,
                            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31,MobileNumber="0778965412",StudentEmail="xx@gmail.com" } ,
                            new Student() { StudentId = 6, StudentName = "Chris" , Age = 17,MobileNumber="0778965412",StudentEmail="xx@gmail.com" } ,
                            new Student() { StudentId = 7, StudentName = "Rob" , Age = 19,MobileNumber="0778965412",StudentEmail="xx@gmail.com"}
                        };

        // GET: Student
        public ActionResult Index()
        {
            return View(studentList);
        }
    
        public ActionResult Edit(int? id)
        {
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
            var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();

            if (std.StudentId != 0)
            {
                if (ModelState.IsValid)
                {//Edit Student
                 //   bool nameAlreadyExists = studentList.Any(n => n.StudentName == std.StudentName); 
                    if (studentList.Any(n => n.StudentName == std.StudentName && n.StudentId != std.StudentId))
                    {
                        ModelState.AddModelError("StudentName", "StudentName already exists");
                        return View(std);
                    }
                    else { 
                    student.StudentName = std.StudentName;
                    student.Age = std.Age;
                    student.StudentId = std.StudentId;
                    student.MobileNumber = std.MobileNumber;
                    student.StudentEmail = std.StudentEmail;
                    }
                    return RedirectToAction("Index");
                }
                else
                {

                    return View(std);
                }
            }
            else
            {
                //Add new Student
                if (ModelState.IsValid)
                {//Create (Duplicate name) validation
                    bool nameAlreadyExists =studentList.Any(n=>n.StudentName == std.StudentName); ;
                    if (nameAlreadyExists)
                    { ModelState.AddModelError("StudentName", "StudentName already exists");
                        return View(std);
                    }

                    else
                    {
                        std.StudentId = studentList.Max(x => x.StudentId) + 1;
                        studentList.Add(std);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(std);
                }

            }

        }
        public ActionResult Details(int Id)
        {//Show Student Details
            var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(std);
        }
        public ActionResult Delete(int id)
        {
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