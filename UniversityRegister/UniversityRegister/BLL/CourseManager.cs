using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.DAL;
using UniversityRegister.MODELS;

namespace UniversityRegister.BLL
{
    public class CourseManager
    {
        CourseAcceser courseAcceser = new CourseAcceser();
        public bool nameExist(string name)
        {
            return courseAcceser.NameExist(name);
        }

        public bool CodeExist(string code)
        {
            return courseAcceser.CodeExist(code);

        }

        public string SendCourseData(string courseName, string courseCode)
        {
            if (nameExist(courseName))
            {
                return "Course name already exist";
            }

            if (CodeExist(courseCode))
            {
                return "Course code already exist";
            }

            bool isSaved = courseAcceser.SendCourseData(courseName, courseCode);
            if (isSaved)
            {
                return "Course saved successfully";
            }
            return "Course saving failed";
        }

        public List<BringCourseData> GetAllCourseDatas()
        {
            return courseAcceser.GetAllCourseDatas();
        }
    }
}