using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repos
{
    interface IStudentRepo
    {
        List<Student> GetAll();
        void Delete(int id);
        void Edit(Student toEdit);
        Student GetById(int id);
    }
}
