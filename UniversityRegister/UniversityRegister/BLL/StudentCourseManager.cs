using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.DAL;

namespace UniversityRegister.MODELS
{
    public class StudentCourseManager
    {
        StudentCourseAccesor courseAccesor = new StudentCourseAccesor();
        public List<BringStudentCourse> GetallStudent()
        {
            return courseAccesor.GetallStudent();
        }
    }
}