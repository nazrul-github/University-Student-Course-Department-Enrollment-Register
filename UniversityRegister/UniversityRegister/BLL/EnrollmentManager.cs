using System;
using System.Collections.Generic;
using UniversityRegister.MODELS;

namespace UniversityRegister.BLL
{
    public class EnrollmentManager
    {
        EnrollmentAccesser accesser = new EnrollmentAccesser();
        public string SendEnrollment(string studentId, string courseId, DateTime enrollmentDate)
        {
            bool isSaved = accesser.SendEnrollment(studentId, courseId, enrollmentDate);
            if (isSaved)
            {
                return "Student enrolled successfully";
            }

            return "Student enrollment failed";

        }

        public List<BringEnrollmentData> GetallEnrollmentData()
        {
            return accesser.GetallEnrollmentData();
        }
    }
}