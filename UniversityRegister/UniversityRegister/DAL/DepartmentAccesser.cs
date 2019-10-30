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
    public class DepartmentAccesser
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public bool nameExist(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "SELECT * FROM tbl_Department WHERE DepartmentName = @DepartmentName";
                cmd.Parameters.AddWithValue("@DepartmentName", name);
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
                    "SELECT * FROM tbl_Department WHERE DepartmentCode = @DepartmentCode";
                cmd.Parameters.AddWithValue("@DepartmentCode", code);
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

        public bool SendDepartment(string departmentName, string departmnetCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_Insert_Department";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                cmd.Parameters.AddWithValue("@DepartmentCode", departmnetCode);
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

        public List<BringDepartmentData> GetAllCourseDatas()
        {
            List<BringDepartmentData> allDepartmentDatas = new List<BringDepartmentData>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_Department";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BringDepartmentData aDepartmentData = new BringDepartmentData();
                    aDepartmentData.GetValue(reader["DepartmentName"].ToString(), reader["DepartmentCode"].ToString());
                    allDepartmentDatas.Add(aDepartmentData);
                }
                reader.Close();
                connection.Close();

                return allDepartmentDatas;
            }
        }
    }
}