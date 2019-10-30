using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;

namespace UniversityRegister.MODELS
{
    public class SendDepartment
    {
        DepartmentManager departmentManager = new DepartmentManager();
        public string DepartmentName { get; private set; }
        public string DepartmnetCode { get; private set; }

        public string SetValue(string name, string code)
        {
            this.DepartmentName = name;
            this.DepartmnetCode = code;
            return SendDepartmentData();
        }

        private string SendDepartmentData()
        {
            return departmentManager.SendDepartment(this.DepartmentName, this.DepartmnetCode);
        }
    }
}