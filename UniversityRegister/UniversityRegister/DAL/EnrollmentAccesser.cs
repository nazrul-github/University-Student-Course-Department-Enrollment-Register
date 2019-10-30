using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityRegister.MODELS;

namespace UniversityRegister.BLL
{
    public class EnrollmentAccesser
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public bool SendEnrollment(string studentId, string courseId, DateTime enrollmentDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_Insert_Enrollment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                cmd.Parameters.AddWithValue("@EnrollmentDate", enrollmentDate);
                connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    connection.Close();
                    return true;
                }

                connection.Close();

                return false;
            }
        }

        public List<BringEnrollmentData> GetallEnrollmentData()
        {
            List<BringEnrollmentData> allEnrollment = new List<BringEnrollmentData>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_Enrollment";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BringEnrollmentData aEnrollment = new BringEnrollmentData();
                    aEnrollment.GetValue(reader["StudentID"].ToString(), reader["CourseID"].ToString(), Convert.ToDateTime(reader["EnrollmentDate"]));
                    allEnrollment.Add(aEnrollment);
                }
                reader.Close();
                connection.Close();

                return allEnrollment;
            }
        }
    }
}
