using System;
using System.Collections.Generic;

namespace CourseManager.Models
{
    public class EditTeacherViewModel
    {

        public Teacher ToEdit { get; set; }
        public List<Course> AllCourses { get; set; }
        public List<Student> AllStudents { get; set; }
        public int[] CourseIds { get; set; }

    }
}
