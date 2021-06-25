using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCourseManager.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public Teacher Teacher { get; set; }

        public Course(Course copy)
        {
            Id = copy.Id;
            Name = copy.Name;
            Students = copy.Students;
            Teacher = copy.Teacher;
        }

        public Course() { }
    }
}
