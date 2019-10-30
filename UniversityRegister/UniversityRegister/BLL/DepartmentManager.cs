using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.DAL;
using UniversityRegister.MODELS;

namespace UniversityRegister.BLL
{
    public class DepartmentManager
    {
        DepartmentAccesser departmentAccesser = new DepartmentAccesser();
        public bool nameExist(string name)
        {
            return departmentAccesser.nameExist(name);
        }

        public bool CodeExist(string code)
        {
            return departmentAccesser.CodeExist(code);

        }

        public string SendDepartment(string departmentName, string departmnetCode)
        {
            if (nameExist(departmentName))
            {
                return "Department name already exist";
            } if (CodeExist(departmnetCode))
            {
                return "Department code already exist";
            }

            if (departmnetCode.Length != 4)
            {
                return "Department code should be 4 character";
            }
            bool isSaved = departmentAccesser.SendDepartment(departmentName, departmnetCode);

            if (isSaved)
            {
                return "Department saved successfully";
            }
            return "Department saving failed";
        }

        public List<BringDepartmentData> GetAllCourseDatas()
        {
            return departmentAccesser.GetAllCourseDatas();
        }
    }
}