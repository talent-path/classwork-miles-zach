using EFCourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCourseManager.Repos
{
    public class StudentRepo
    {
        public CourseDbContext _context { get; set; }
        public StudentRepo(CourseDbContext context)
        {
            _context = context;
        }

        internal Student GetStudent(int id)
        {
            return _context.Students.Find(id);
        }
    }
}
