using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;

namespace UniversityRegister.MODELS
{
    public class BringEnrollmentData
    {
        EnrollmentManager enrollmentManager = new EnrollmentManager();
        public string StudentID { get; set; }
        public string CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        List<BringEnrollmentData> enrollmentData = new List<BringEnrollmentData>();

        public List<BringEnrollmentData> GetallEnrollmentData()
        {
            return enrollmentManager.GetallEnrollmentData();
        }
        public void GetValue(string studentID, string courseID, DateTime enrollmentDate)
        {
            this.StudentID = studentID;
            this.CourseID = courseID;
            this.EnrollmentDate = enrollmentDate;
        }
    }
}