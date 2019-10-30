using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegister.DAL;
using UniversityRegister.MODELS;

namespace UniversityRegister.BLL
{
    public class StudentManager
    {
        StudentDataAccesser dataAccesser = new StudentDataAccesser();


        private bool MobileNumberExist(string mobile,string registrationNumber)
        {
            return dataAccesser.MobileNumberExist(mobile,registrationNumber);
        }

        private bool EmailExist(string email,string registrationNumber)
        {
            return dataAccesser.EmailExist(email,registrationNumber);
        }
        private bool RegistrationNumberExist(string registrationNumber)
        {
            return dataAccesser.RegistrationNumberExist(registrationNumber);
        }
        public string SendStudent(string studentName, string mobileNumber, string email, string departmentID,string registrationNumber)
        {
            if (MobileNumberExist(mobileNumber,registrationNumber))
            {
                return "Mobile number already exist";
            }
            if (EmailExist(email,registrationNumber))
            {
                return "Email already exist";
            }

            if (mobileNumber.Length != 11)
            {
                return "Mobile Number Should be 11 Character";
            }

            if (RegistrationNumberExist(registrationNumber))
            {
                return "Registration number already exist";
            }
            bool isSaved = dataAccesser.SaveStudent(studentName, mobileNumber, email, departmentID,registrationNumber);
            if (isSaved)
            {
                return "Student saved successfully";
            }
            return "Student saving failed";
        }

       

        public List<BringStudentData> GetallStudent()
        {
            return dataAccesser.GetallStudent();
        }
        public List<BringStudentData> GetallStudentTextBox(string regno)
        {
            return dataAccesser.GetallStudentTextBox(regno);
        }

        public string UpdateStudent(string studentName, string mobileNumber, string email, string departmentID, string regestretionNumber)
        {

            if (MobileNumberExist(mobileNumber,regestretionNumber))
            {
                return "Mobile number already exist";
            }
            if (EmailExist(email,regestretionNumber))
            {
                return "Email already exist";
            }

            if (mobileNumber.Length != 11)
            {
                return "Mobile Number Should be 11 Character";
            }

            if (RegistrationNumberExist(regestretionNumber))
            {
                return "Registration number already exist";
            }
            bool isSaved = dataAccesser.SaveStudent(studentName, mobileNumber, email, departmentID,regestretionNumber);
            if (isSaved)
            {
                return "Student saved successfully";
            }
            return "Student saving failed";
        }
    }

}
