using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;
using UniversityRegister.DAL;

namespace UniversityRegister.MODELS
{
    public class SendEnrollment
    {
        EnrollmentManager enrollmentManager = new EnrollmentManager();
        public string StudentId { get; private set; }
        public string CourseId { get; private set; }
        public DateTime EnrollmentDate { get; set; }

        public string SaveEnrollmentData(string id, string course, DateTime date)
        {
            this.StudentId = id;
            this.CourseId = course;
            this.EnrollmentDate = date;
          return  SendEnrollmentData();
        }
      

        private string SendEnrollmentData()
        {
            return enrollmentManager.SendEnrollment(this.StudentId, this.CourseId,this.EnrollmentDate);
           
        }
    }
}