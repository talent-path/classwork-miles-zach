using System;
using System.Linq;
using System.Collections.Generic;
using CourseManager.Models;
using System.Data.SqlClient;
using System.Data;

namespace CourseManager.Repos
{
    public class DBStudentRepo : DbRepo, IStudentRepo
    {
        public Student ConvertTableRow(DataRow row)
        {
            Student toReturn = new Student();

            var setId = row.Field<int>("Id");
            var setName = row.Field<string>("Name");

            toReturn.Name = setName;
            toReturn.Id = setId;

            return toReturn;
        }

        public Student GetById(int id)
        {
            Student toReturn = null;
            DataSet set = ExecuteQuery("SELECT Id, Name FROM Students WHERE Id =" + id);
            var table = set.Tables[0];
            if (table.Rows.Count == 1)
            {
                toReturn = new Student();
                var setId = int.Parse(table.Rows[0]["Id"].ToString());
                var name = table.Rows[0].Field<string>("Name");
                toReturn.Id = setId;
                toReturn.Name = name;
                // TODO need list of courses
            }

            return toReturn;
        }

        public int AddStudent(Student toadd)
        {
            DataSet set = new DataSet();

            if (toadd == null)
                throw new NoNullAllowedException("Student can not be null");
            else
            {
                set = ExecuteQuery($"insert into Students (name) output INSERTED.id values ({toadd.Name})");
            }

            return int.Parse(set.Tables[0].Rows[0]["id"].ToString());
        }

        public void Edit(Student updated)
        {
            DataSet set = new DataSet();

            if (updated == null)
                throw new NoNullAllowedException("Student can not be null");
            else
            {
                set = ExecuteQuery($"update Students set name = {updated.Name} where id = {updated.Id}");
            }
        }

        public void Delete(int id)
        {
            DataSet set = ExecuteQuery($"delete from StudentCourses where StudentId = {id}");
            set = ExecuteQuery($"delete from Students where id = {id}");
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            DataSet set = ExecuteQuery("SELECT Id, Name FROM Students");

            int rowsNum = set.Tables[0].Rows.Count;

            for (int i = 0; i < rowsNum; i++)
            {
                students.Add(ConvertTableRow(set.Tables[0].Rows[i]));
            }

            return students;
        }

    }
}

