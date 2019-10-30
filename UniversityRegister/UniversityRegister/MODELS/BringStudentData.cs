using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;

namespace UniversityRegister.MODELS
{
    public class BringStudentData
    {
        StudentManager studentManager = new StudentManager();
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public string RegNO { get; set; }
        public List<BringStudentData> aStudent = new List<BringStudentData>();

        public List<BringStudentData> GetallStudent()
        {
            aStudent = studentManager.GetallStudent();
            return aStudent;
        }

        public BringStudentData AStudentData(string regNo)
        {
            BringStudentData aStudentData = new BringStudentData();
            foreach (var item in aStudent)
            {
                while (item.RegNO == regNo)
                {
                    aStudentData.DepartmentId = item.DepartmentId;
                    aStudentData.RegNO = item.RegNO;
                    aStudentData.Email = item.Email;
                    aStudentData.StudentID = item.StudentID;
                    aStudentData.MobileNumber = item.MobileNumber;
                    aStudentData.StudentName = item.StudentName;
                }
            }

            return aStudentData;
        }

        internal void GetValue(string studentId, string studentName, string mobileNumber, string email,string departmetnID, string regno)
        {
            this.StudentID = studentId;
            this.StudentName = studentName;
            this.MobileNumber = mobileNumber;
            this.Email = email;
            this.DepartmentId = departmetnID;
            this.RegNO = regno;
        }
    }
}