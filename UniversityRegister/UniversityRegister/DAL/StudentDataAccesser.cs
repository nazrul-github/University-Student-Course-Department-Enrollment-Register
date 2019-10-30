using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityRegister.MODELS;

namespace UniversityRegister.DAL
{
    public class StudentDataAccesser
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public bool IsExist(string validation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "SELECT * FROM tbl_Student WHERE MobileNumber = @Validation or EmailAddress = @Validation;";
                cmd.Parameters.AddWithValue("@Validation", validation);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool MobileNumberExist(string mobile, string registrationNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "SELECT * FROM tbl_Student WHERE RegestretionNumber != @registrationNumber AND MobileNumber = @mobile;";
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@registrationNumber", registrationNumber);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    connection.Close();
                    return true;
                }

                reader.Close();
                connection.Close();
                return false;


            }
        }

        public bool EmailExist(string email, string registrationNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "SELECT * FROM tbl_Student WHERE RegestretionNumber != @registrationNumber AND EmailAddress = @email;";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@registrationNumber", registrationNumber);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    connection.Close();
                    return true;
                }

                reader.Close();
                connection.Close();
                return false;

            }

        }
        public bool RegistrationNumberExist(string registrationNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "SELECT * FROM tbl_Student WHERE RegestretionNumber = @RegestretionNumber;";
                cmd.Parameters.AddWithValue("@RegestretionNumber", registrationNumber);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    connection.Close();
                    return true;
                }

                reader.Close();
                connection.Close();
                return false;

            }
        }
        public bool SaveStudent(string studentName, string mobileNumber, string email, string departmentID, string reginum)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_Insert_Student";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentName", studentName);
                cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", email);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
                cmd.Parameters.AddWithValue("@RegestretionNumber", reginum);

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

        public List<BringStudentData> GetallStudentTextBox(string regno)
        {

            List<BringStudentData> allStudent = new List<BringStudentData>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_Student WHERE RegestretionNumber = @RegestretionNumber";
                cmd.Parameters.AddWithValue("@RegestretionNumber", regno);
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BringStudentData aStudentData = new BringStudentData();
                    aStudentData.GetValue(reader["StudentID"].ToString(), reader["StudentName"].ToString(), reader["MobileNumber"].ToString(),
                        reader["EmailAddress"].ToString(), reader["DepartmentID"].ToString(), reader["RegestretionNumber"].ToString());
                    allStudent.Add(aStudentData);
                }
                reader.Close();
                connection.Close();

                return allStudent;
            }
        }
        public List<BringStudentData> GetallStudent()
        {

            List<BringStudentData> allStudent = new List<BringStudentData>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_Student;";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BringStudentData aStudentData = new BringStudentData();
                    aStudentData.GetValue(reader["StudentID"].ToString(), reader["StudentName"].ToString(), reader["MobileNumber"].ToString(),
                        reader["EmailAddress"].ToString(), reader["DepartmentID"].ToString(), reader["RegestretionNumber"].ToString());
                    allStudent.Add(aStudentData);
                }
                reader.Close();
                connection.Close();

                return allStudent;
            }
        }


    }
}
