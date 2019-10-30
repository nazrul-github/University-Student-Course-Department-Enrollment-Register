using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;

namespace UniversityRegister.MODELS
{
    public class BringCourseData
    {
        CourseManager courseManager = new CourseManager();
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        List<BringCourseData> allCourse = new List<BringCourseData>();

        public List<BringCourseData> GetAllCourseDatas()
        {
            return courseManager.GetAllCourseDatas();
        }
        public void GetValue(string bookName, string ISBNnumber)
        {
            this.CourseName = bookName;
            this.CourseCode = ISBNnumber;
        }
    }
}