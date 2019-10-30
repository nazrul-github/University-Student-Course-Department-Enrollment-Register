using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityRegister.MODELS;

namespace UniversityRegister
{
    public partial class AddStudent : System.Web.UI.Page
    {
        SendStudent aSendStudent = new SendStudent();
        BringStudentData aBringStudentData = new BringStudentData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentCode";
                ddlDepartment.DataSource = aSendStudent.GetDeparmentDDL();
                ddlDepartment.DataBind();

                LoadStudentDDL();


            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string studentName = studentNameTextBox.Text;
            string mobileNumber = mobileNumberTextBox.Text;
            string emailAddress = emailAddressTextBox.Text;
            string registrationNumber = registrationNumberTextBox.Text;
            string departmentID = ddlDepartment.SelectedItem.Value;
           msgLabel.Text = aSendStudent.SetValue(studentName, mobileNumber, emailAddress, departmentID, registrationNumber);
            GetClear();
            LoadStudentDDL();
        }

        protected void ddlupdateDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetClear();
            saveButton.Enabled = false;
            BringStudentData bringStudent = new BringStudentData();
            bringStudent = (aBringStudentData.AStudentData(ddlupdateDelete.SelectedValue));
            studentNameTextBox.Text = bringStudent.StudentName;
            mobileNumberTextBox.Text = bringStudent.MobileNumber;
            emailAddressTextBox.Text = bringStudent.Email;
            registrationNumberTextBox.Text = bringStudent.RegNO;
            ddlDepartment.SelectedValue = bringStudent.DepartmentId;
        }

        private void LoadStudentDDL()
        {
            ddlupdateDelete.DataTextField = "StudentName";
            ddlupdateDelete.DataValueField = "RegNO";
            ddlupdateDelete.DataSource = aBringStudentData.GetallStudent();
            ddlupdateDelete.DataBind();
        }
        private void GetClear()
        {
            studentNameTextBox.Text = string.Empty;
            mobileNumberTextBox.Text = String.Empty;
            emailAddressTextBox.Text = string.Empty;
            registrationNumberTextBox.Text = string.Empty;
            ddlDepartment.SelectedIndex = 0;
        }
    }
}