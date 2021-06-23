using System;
using System.Collections.Generic;
using System.Linq;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Repos;

namespace CourseManager.Services
{
    public class CourseService
    {
        ICourseRepo _courseRepo = new DBCourseRepo();
        ITeacherRepo _teacherRepo = new DBTeacherRepo();
        IStudentRepo _studentRepo = new DBStudentRepo();

        public List<Course> GetAll()
        {
            return _courseRepo.GetAll();
        }

        public List<Teacher> GetAllTeachers()
        {
            return _teacherRepo.GetAll();
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepo.GetAll();
        }

        public Course GetById(int id)
        {
            Course toReturn = _courseRepo.GetById(id);

            if( toReturn == null)
            {
                throw new CourseNotFoundException($"No course has an id of {id}.");
            }

            return toReturn;
        }


        public Teacher GetTeacherById(int id)
        {
            Teacher toReturn = _teacherRepo.GetById(id);

            if (toReturn == null)
            {
                throw new TeacherNotFoundException($"No teacher has an id of {id}.");
            }

            return toReturn;
        }

        public void DeleteCourse(int id)
        {
            _courseRepo.Delete(id);
        }

        public void DeleteTeacher(int id)
        {
            _teacherRepo.Delete(id);
        }

        public void DeleteStudent(int id)
        {
            _studentRepo.Delete(id);
        }

        public void EditCourse(Course toEdit)
        {
            _courseRepo.Edit(toEdit);


        }

        public void EditTeacher(Teacher toEdit)
        {
            _teacherRepo.Edit(toEdit);
        }

        public void EditStudent(Student toEdit)
        {
            _studentRepo.Edit(toEdit);
        }

        public Student GetStudentById(int id)
        {
            return _studentRepo.GetById(id);
        }
    }
}
