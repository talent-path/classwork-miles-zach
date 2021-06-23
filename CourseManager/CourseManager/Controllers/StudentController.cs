using System;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers
{
    public class StudentController : Controller
    {
        CourseService _service = new CourseService();

        public StudentController()
        {
        }

        public IActionResult Index()
        {
            //1. ask service for the list of courses
            var students = _service.GetAllStudents();
            //2. send list off to view
            return View(students);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    Student toDisplay = _service.GetStudentById(id.Value);
                    return View(toDisplay);

                }
                catch (StudentNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }
    }
}
