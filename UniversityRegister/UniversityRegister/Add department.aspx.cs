using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityRegister.MODELS;

namespace UniversityRegister
{
    public partial class WebForm1 : System.Web.UI.Page
    {
     SendDepartment aDepartment = new SendDepartment();   
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string departmentName = departmentNameTextBox.Text;
                string departmentCode = departmentCodeTextBox.Text;
                msgLabel.Text = aDepartment.SetValue(departmentName, departmentCode);
            }
            else
            {
                msgLabel.Text = "Validation Failed";
                msgLabel.ForeColor = Color.Red;
            }

        }
    }
}