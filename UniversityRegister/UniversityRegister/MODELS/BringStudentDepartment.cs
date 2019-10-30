using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;

namespace UniversityRegister.MODELS
{
    public class BringStudentDepartment
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string DepartmentName { get; set; }
        StudentDepartmentManager studentDepartmentManager = new StudentDepartmentManager();
        
        public List<BringStudentDepartment> GetallStudentDepartments()
        {
            return studentDepartmentManager.GetallStudent();
        }
        public void GetValue(string studentName, string mobileNumber, string email, string departmentName)
        {
            this.StudentName = studentName;
            this.MobileNumber = mobileNumber;
            this.EmailAddress = email;
            this.DepartmentName = departmentName;
        }

    }
}