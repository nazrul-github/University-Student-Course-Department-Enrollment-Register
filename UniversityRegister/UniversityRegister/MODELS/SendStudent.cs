using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.BLL;

namespace UniversityRegister.MODELS
{
    public class SendStudent
    {
        StudentManager studentManager = new StudentManager();
        BringDepartmentData aDepartmentData = new BringDepartmentData();
        public string StudentName { get; private set; }
        public string MobileNumber { get; private set; }
        public string Email { get; private set; }
        public string DepartmentID { get; set; }
        public string RegestretionNumber { get; set; }

        public string SetValue(string name, string mobile, string email,string departmetnId,string regestretionNumber)
        {
            
                this.StudentName = name;
                this.MobileNumber = mobile;
                this.Email = email;
                this.DepartmentID = departmetnId;
                this.RegestretionNumber = regestretionNumber;
                return SendStudentData();
            
        }

        private string SendStudentData()
        {
          return studentManager.SendStudent(this.StudentName, this.MobileNumber, this.Email,this.DepartmentID, this.RegestretionNumber);
           
        }

        public string UpdateStudentData()
        {
            return studentManager.UpdateStudent(this.StudentName, this.MobileNumber, this.Email, this.DepartmentID, this.RegestretionNumber);

        }

        public List<BringDepartmentData> GetDeparmentDDL()
        {
            return aDepartmentData.GetAllDepartmentDatas();
        }
    }



}
