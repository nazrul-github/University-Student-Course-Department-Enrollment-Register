using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityRegister.MODELS;

namespace UniversityRegister.DAL
{
    public class StudentCourseAccesor
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<BringStudentCourse> GetallStudent()
        {
            List<BringStudentCourse> allStudentCourses = new List<BringStudentCourse>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM studentCourse";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BringStudentCourse aStudentData = new BringStudentCourse();
                    aStudentData.GetValue(reader["StudentID"].ToString(), reader["StudentName"].ToString(), reader["MobileNumber"].ToString(),
                        reader["EmailAddress"].ToString(), reader["DepartmentName"].ToString(), reader["CourseName"].ToString(), Convert.ToDateTime(reader["EnrollmentDate"]));
                    allStudentCourses.Add(aStudentData);
                }
                reader.Close();
                connection.Close();

                return allStudentCourses;
            }
        }
    }
}