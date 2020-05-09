using FormHelper;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentProject.Controllers
{
    public class HomeController : Controller
    {
        private static List<Student> _studentList = new List<Student>();

        public IActionResult List()
        {
            return View(_studentList);
        }

        public IActionResult Form(int? id)
        {
            if (id.HasValue == true)
            {
                var student = _studentList.Single(x => x.Id == id.Value);
                return View(student);
            }
            else
            {
                return View(new Student());
            }
        }

        [FormValidator]
        public IActionResult Save(Student student)
        {
            if (student.IsNew)
            {
                if(_studentList.Any(x => x.StudentNumber == student.StudentNumber))
                {
                    return FormResult.CreateWarningResult("Aynı öğrenci numarasını kullanan başka bir öğrenci vardır.");
                }

                _studentList.Add(student);
                return FormResult.CreateSuccessResult("Öğrenci eklendi.", Url.Action("List", "Home"));
            }
            else
            {
                var currentStudent = _studentList.Single(x => x.Id == student.Id);
                currentStudent = student;
                return FormResult.CreateSuccessResult("Öğrenci güncellendi.", Url.Action("List", "Home"));
            }
        }
    }
}
