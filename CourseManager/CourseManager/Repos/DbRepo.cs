using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Models;

namespace CourseManager.Repos
{
    public abstract class DbRepo
    {

        string _connectionString = "Server=localhost;Database=CourseManager;Trusted_Connection=True;";

        public DataSet ExecuteQuery(string sql)
        {
            DataSet set = new DataSet();

            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(set);
            }

            return set;
        }

    }
}
