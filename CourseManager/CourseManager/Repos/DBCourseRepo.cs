using System;
using System.Linq;
using CourseManager.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CourseManager.Repos
{
    public class DBCourseRepo : DbRepo, ICourseRepo
    {
        public Course ConvertTableRow(DataRow row)
        {
            Course toReturn = new Course();

            var setId = row.Field<int>("Id");
            var setName = row.Field<string>("Name");

            toReturn.Name = setName;
            toReturn.Id = setId;
            toReturn.ClassTeacher = GetTeacherById(row.Field<int>("TeacherId"));

            return toReturn;

        }

        public Teacher GetTeacherById(int teacherId)
        {
            Teacher teacher = new Teacher();
            DataSet set = ExecuteQuery($"SELECT Id, Name FROM Teachers WHERE Id = {teacherId}");
            var table = set.Tables[0];
            if(table.Rows.Count == 1)
            {
                teacher.Id = table.Rows[0].Field<int>("Id");
                teacher.Name = table.Rows[0].Field<string>("Name");
            }
            return teacher;
        }

        public List<Student> GetStudentsByCourseId(int courseId)
        {
            List<Student> students = new List<Student>();
            DataSet set = ExecuteQuery($"select Id, Name from Students as s where Id in " +
                $"(select StudentId from StudentCourses as sc inner join Courses as c on sc.CourseId = {courseId});");
            var table = set.Tables[0];
            if(table.Rows.Count > 0)
            {
                foreach(DataRow row in table.Rows)
                {
                    Student student = new Student { Id = row.Field<int>("Id"), Name = row.Field<string>("Name") };
                    students.Add(student);
                }
            }
            return students;
        }

        public Course GetById(int id)
        {
            Course toReturn = null;
            DataSet set = ExecuteQuery("SELECT Id, Name, TeacherId FROM Courses WHERE Id =" + id);
            var table = set.Tables[0];
            if (table.Rows.Count == 1)
            {
                toReturn = new Course();
                toReturn.Id = table.Rows[0].Field<int>("Id");
                toReturn.Name = table.Rows[0].Field<string>("Name");
                toReturn.ClassStudents = GetStudentsByCourseId(table.Rows[0].Field<int>("Id"));
                toReturn.ClassTeacher = GetTeacherById(table.Rows[0].Field<int>("TeacherId"));
            }

            return toReturn;
        }

        public int AddCourse(Course toAdd)
        {
            DataSet set = new DataSet();

            if (toAdd == null)
                throw new NoNullAllowedException("Course can not be null");
            else
            {
                set = ExecuteQuery($"INSERT INTO Courses (Name) OUTPUT INSERTED.Id VALUES ({toAdd.Name})");
            }

            return int.Parse(set.Tables[0].Rows[0]["Id"].ToString());
        }

        public void Edit(Course updated)
        {
            DataSet set = new DataSet();

            if (updated == null)
                throw new NoNullAllowedException("Course can not be null");
            else
            {
                //Compare Students before and after, Update StudentCourses
                List<Student> beforeEdit = GetStudentsByCourseId(updated.Id.Value);
                foreach(Student student in updated.ClassStudents)
                {
                    if(!beforeEdit.Contains(student))
                    {
                        ExecuteQuery($"INSERT INTO StudentCourses (CourseId, StudentId) VALUES ({updated.Id.Value}, {student.Id})");
                    }
                }

                foreach (Student student in beforeEdit)
                {
                    if (!updated.ClassStudents.Contains(student))
                    {
                        ExecuteQuery($"DELETE FROM StudentCourses WHERE CourseId = {updated.Id} AND StudentId = {student.Id}");
                    }
                }

                ExecuteQuery($"UPDATE Courses SET Name = '{updated.Name}', TeacherId = {updated.ClassTeacher.Id} WHERE Id = {updated.Id}");
            }
        }

        public void Delete(int id)
        {
            ExecuteQuery($"DELETE FROM StudentCourses WHERE CourseId = {id}");
            ExecuteQuery($"DELETE FROM Courses WHERE Id = {id}");
        }

        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();

            DataSet set = ExecuteQuery("SELECT Id, Name, TeacherId FROM Courses");

            foreach(DataRow row in set.Tables[0].Rows)
            {
                courses.Add(ConvertTableRow(row));
            }

            return courses;
        }
    }
}
