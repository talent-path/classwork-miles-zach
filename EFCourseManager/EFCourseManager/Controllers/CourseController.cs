using EFCourseManager.Models;
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
    [Route("/api/course")]
    public class CourseController : Controller
    {
        CourseService _courseService;
        public CourseController(CourseDbContext context)
        {
            _courseService = new CourseService(context);
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            return CreatedAtAction(nameof(GetCourse), _courseService.AddCourse(course));
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            return Ok(_courseService.GetCourse(id));
        }

    }
}
