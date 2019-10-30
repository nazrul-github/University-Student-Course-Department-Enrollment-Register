using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegister.MODELS
{
    public class BringStudentCourse
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string DepartmentName { get; set; }
        public string CourseName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        StudentCourseManager courseManager = new StudentCourseManager();

        public List<BringStudentCourse> GetallStudentCourseManagers()
        {
            return courseManager.GetallStudent();
        }
        public void GetValue(string studentID, string studentName, string mobileNumber, string email, string departmentName, string courseName, DateTime enrollmentDate)
        {
            this.StudentID = studentID;
            this.StudentName = studentName;
            this.MobileNumber = mobileNumber;
            this.EmailAddress = email;
            this.DepartmentName = departmentName;
            this.CourseName = courseName;
            this.EnrollmentDate = enrollmentDate;
        }
    }
}