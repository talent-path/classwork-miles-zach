using EFCourseManager.Repos;
using EFCourseManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCourseManager.Controllers
{
    [ApiController]
    [Route("/api/student")]
    public class StudentController : Controller
    {

        CourseService _service;

        public StudentController(CourseDbContext context)
        {
            _service = new CourseService(context);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            return Ok(_service.GetStudent(id));
        }
    }
}
