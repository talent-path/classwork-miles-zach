using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repos
{
    interface ICourseRepo
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Delete(int id);
        void Edit(Course toEdit);
    }
}
