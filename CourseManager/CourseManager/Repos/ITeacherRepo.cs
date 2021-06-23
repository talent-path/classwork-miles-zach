using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repos
{
    interface ITeacherRepo
    {
        List<Teacher> GetAll();
        Teacher GetById(int id);
        void Delete(int id);
        void Edit(Teacher toEdit);
    }
}
