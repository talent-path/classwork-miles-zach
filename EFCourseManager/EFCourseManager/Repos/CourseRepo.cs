using EFCourseManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCourseManager.Repos
{
    public class CourseRepo
    {
        public CourseDbContext _context { get; set; }
        public CourseRepo(CourseDbContext context)
        {
            _context = context;
        }

        internal Course AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        internal Course GetCourse(int id)
        {
            return _context.Courses
                .Include(c => c.Students)
                .Select(c => new Course
                {
                    Id = c.Id,
                    Name = c.Name,
                    Teacher = c.Teacher,
                    Students = c.Students.Select(s => new Student { Id = s.Id, Name = s.Name }).ToList()
                })
                .Single(c => c.Id == id);
        }
    }
}
