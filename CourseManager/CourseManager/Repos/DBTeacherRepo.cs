using System;
using System.Linq;
using System.Collections.Generic;
using CourseManager.Models;
using System.Data.SqlClient;
using System.Data;

namespace CourseManager.Repos
{
    public class DBTeacherRepo :  DbRepo, ITeacherRepo
    {

        public Teacher ConvertTableRow(DataRow row)
        {
            Teacher toReturn = new Teacher();

            var setId = row.Field<int>("Id");
            var setName = row.Field<string>("Name");

            toReturn.Name = setName;
            toReturn.Id = setId;

            return toReturn;
        }

        public Teacher GetById(int id)
        {
            Teacher toReturn = null;
            DataSet set = ExecuteQuery("SELECT Id, Name FROM Teachers WHERE Id =" + id);
            var table = set.Tables[0];
            if(table.Rows.Count == 1)
            {
                toReturn = new Teacher();
                var setId = int.Parse(table.Rows[0]["Id"].ToString());
                var name = table.Rows[0].Field<string>("Name");
                toReturn.Id = setId;
                toReturn.Name = name;

            }

            return toReturn;
        }

        public int AddTeacher(Teacher toAdd)
        {
            DataSet set = new DataSet();

            if (toAdd == null)
                throw new NoNullAllowedException("Teacher can not be null");
            else
            {
                set = ExecuteQuery($"INSERT INTO Teachers (Name) OUTPUT INSERTED.Id VALUES ({toAdd.Name})");
            }

            return int.Parse(set.Tables[0].Rows[0]["Id"].ToString());
        }

        public void Edit(Teacher updated)
        {
            DataSet set = new DataSet();

            if (updated == null)
                throw new NoNullAllowedException("Teacher can not be null");
            else
            {
                set = ExecuteQuery($"UPDATE Teachers SET Name = {updated.Name} WHERE Id = {updated.Id}");
            }
        }

        public void Delete(int id)
        {
            DataSet set = ExecuteQuery($"DELETE FROM Courses WHERE TeacherId = {id}");
            set = ExecuteQuery($"DELETE FROM Teachers WHERE Id = {id}");
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> toReturn = new List<Teacher>();

            DataSet set = ExecuteQuery("SELECT Id, Name FROM Teachers");
            
            foreach(DataRow row in set.Tables[0].Rows)
            {
                toReturn.Add(ConvertTableRow(row));
            }

            return toReturn;

        }
    }
}

