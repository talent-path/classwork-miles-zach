using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CourseManager.Models
{
    public class Student : IEquatable<Student>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Student() { }

        public Student(Student that)
        {
            this.Id = that.Id;
            this.Name = that.Name;
        }

        public bool Equals([AllowNull] Student other)
        {
            return other.Id == Id && other.Name == Name;
        }
    }
}
