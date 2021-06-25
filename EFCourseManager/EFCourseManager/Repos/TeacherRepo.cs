using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCourseManager.Repos
{
    public class TeacherRepo
    {
        public CourseDbContext _context;
        public TeacherRepo(CourseDbContext context)
        {
            _context = context;
        }
    }
}
