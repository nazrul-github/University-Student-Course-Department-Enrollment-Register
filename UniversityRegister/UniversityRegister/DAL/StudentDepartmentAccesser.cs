using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityRegister.MODELS;

namespace UniversityRegister.DAL
{
    public class StudentDepartmentAccesser
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<BringStudentDepartment> GetallStudent()
        {
            List<BringStudentDepartment> allStudentDepartments = new List<BringStudentDepartment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM studentDepartment";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BringStudentDepartment aStudentData = new BringStudentDepartment();
                    aStudentData.GetValue(reader["StudentName"].ToString(), reader["MobileNumber"].ToString(),
                        reader["EmailAddress"].ToString(), reader["DepartmentID"].ToString());
                    allStudentDepartments.Add(aStudentData);
                }
                reader.Close();
                connection.Close();

                return allStudentDepartments;
            }
        }
    }
}