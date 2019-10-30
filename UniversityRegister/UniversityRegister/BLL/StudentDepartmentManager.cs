using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.DAL;
using UniversityRegister.MODELS;

namespace UniversityRegister.BLL
{
    public class StudentDepartmentManager
    {
        StudentDepartmentAccesser studentDepartmentAccesser = new StudentDepartmentAccesser();
        public List<BringStudentDepartment> GetallStudent()
        {
            return studentDepartmentAccesser.GetallStudent();
        }
    }
}