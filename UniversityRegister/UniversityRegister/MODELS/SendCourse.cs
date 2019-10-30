using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;

namespace UniversityRegister.MODELS
{
    public class SendCourse
    {
        CourseManager courseManager = new CourseManager();
        public string CourseName { get; private set; }
        public string CourseCode { get; private set; }

        public string SetValue(string name, string code)
        {
                this.CourseName = name;
                this.CourseCode = code;
                return SendCourseData();
        }

        private string SendCourseData()
        {
           return courseManager.SendCourseData(this.CourseName, this.CourseCode);
        }
    }
}