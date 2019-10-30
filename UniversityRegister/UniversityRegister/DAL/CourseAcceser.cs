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
    public class CourseAcceser
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<BringCourseData> GetAllCourseDatas()
        {
            List<BringCourseData> allCourseDatas = new List<BringCourseData>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_Course";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BringCourseData aCourseData = new BringCourseData();
                    aCourseData.GetValue(reader["CourseName"].ToString(), reader["CourseCode"].ToString());
                    allCourseDatas.Add(aCourseData);
                }
                reader.Close();
                connection.Close();

                return allCourseDatas;
            }
        }

        public bool NameExist(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "SELECT * FROM tbl_Course WHERE CourseName = @CourseName";
                cmd.Parameters.AddWithValue("@CourseName", name);
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

        public bool CodeExist(string code)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "SELECT * FROM tbl_Course WHERE CourseCode = @CourseCode";
                cmd.Parameters.AddWithValue("@CourseCode", code);
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

        public bool SendCourseData(string name, string code)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_Insert_Course";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseName", name);
                cmd.Parameters.AddWithValue("@CourseCode", code);
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
    }
}