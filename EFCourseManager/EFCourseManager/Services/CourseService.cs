using EFCourseManager.Models;
using EFCourseManager.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCourseManager.Services
{
    public class CourseService
    {
        CourseRepo _courseRepo;
        StudentRepo _studentRepo;
        public CourseService(CourseDbContext context)
        {
            _courseRepo = new CourseRepo(context);
            _studentRepo = new StudentRepo(context);
        }

        internal Course AddCourse(Course course)
        {
            return _courseRepo.AddCourse(course);
        }

        internal Course GetCourse(int id)
        {
            return _courseRepo.GetCourse(id);
        }

        internal Student GetStudent(int id)
        {
            return _studentRepo.GetStudent(id);
        }
    }
}
