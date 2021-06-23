using System;
using System.Collections.Generic;
using CourseManager.Models;
using Microsoft.AspNetCore.Mvc;
using CourseManager.Services;
using CourseManager.Exceptions;

namespace CourseManager.Controllers
{
    public class TeacherController : Controller
    {
        CourseService _service = new CourseService();

        public TeacherController()
        {
        }

        public IActionResult Index()
        {
            List<Teacher> teachers = _service.GetAllTeachers();
            return View(teachers);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    Teacher toDisplay = _service.GetTeacherById(id.Value);
                    return View(toDisplay);

                }
                catch (TeacherNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    Teacher toDisplay = _service.GetTeacherById(id.Value);
                    List<Course> allCourses = _service.GetAll();
                    List<Student> allStudents = _service.GetAllStudents();

                    EditTeacherViewModel vm = new EditTeacherViewModel
                    {
                        ToEdit = toDisplay,
                        AllStudents = allStudents,
                        AllCourses = allCourses
                    };

                    return View(vm);

                }
                catch (CourseNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(EditTeacherViewModel vm)
        {
            //if (vm.ToEdit.Id != null)
            //{

            //    Teacher fullyHydratedTeacher
            //        = _service.GetTeacherById(vm.ToEdit.Id.Value);


            //    List<Course> fullyHydratedStudents
            //        = vm.CourseIds.Se(id => _service.GetStudentById(id)).ToList();

            //    vm.ToEdit.ClassTeacher = fullyHydratedTeacher;
            //    vm.ToEdit.ClassStudents = fullyHydratedStudents;

            //    _service.EditCourse(vm.ToEdit);

            //    return RedirectToAction("Index");
            //}

            return BadRequest();
        }
    }
}
