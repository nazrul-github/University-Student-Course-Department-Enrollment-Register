using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;

namespace UniversityRegister.MODELS
{
    public class BringDepartmentData
    {
        DepartmentManager departmentManager = new DepartmentManager();
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }

        public List<BringDepartmentData> GetAllDepartmentDatas()
        {
            return departmentManager.GetAllCourseDatas();
        }
        public void GetValue(string bookName, string ISBNnumber)
        {
            this.DepartmentName = bookName;
            this.DepartmentCode = ISBNnumber;
        }
    }
}