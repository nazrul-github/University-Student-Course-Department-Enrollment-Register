<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="UniversityRegister.AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function IsValid(source, args) {
            if (args.Value == '') {
                args.IsValid = false;
            } else if (args.Value.length != 11) {
                args.IsValid = false;
            }
            args.IsValid = true;
        }
    </script>
    <fieldset>
        <legend>Add Student
        </legend>

        <table class="nav-justified">
            <tr>
                <td>Student Name</td>
                <td>
                    <asp:TextBox ID="studentNameTextBox" CssClass="form-control" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="studentNameTextBoxValidator" ForeColor="red" ControlToValidate="studentNameTextBox" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="Student name is required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Mobile Number</td>
                <td>
                    <asp:TextBox ID="mobileNumberTextBox" CssClass="form-control" runat="server"></asp:TextBox></td>

                <td>
                    <asp:CustomValidator ID="mobileNumberTextBoxValidator" runat="server" ForeColor="red" ControlToValidate="mobileNumberTextBox" Display="Dynamic" SetFocusOnError="True" ClientValidationFunction="IsValid" ErrorMessage="Mobile number should be 11 character"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>Email Address</td>
                <td>
                    <asp:TextBox ID="emailAddressTextBox" CssClass="form-control" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="emailAddressTextBoxRequiredFieldValidator" ForeColor="red" ControlToValidate="emailAddressTextBox" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="Email address is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailAddressTextBoxRegularExpressionValidator" ForeColor="red" ControlToValidate="emailAddressTextBox" Display="Dynamic" runat="server" ErrorMessage="Email address is not in a valid format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Registration Numnber</td>
                <td>
                    <asp:TextBox ID="registrationNumberTextBox" CssClass="form-control" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="registrationNumberTextBoxRequiredFieldValidator" ForeColor="red" ControlToValidate="registrationNumberTextBox" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="registration number is required"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>Department Name</td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server">
                        <asp:ListItem Text="--Select A Department--"></asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator ID="ddlDepartmentValidator" ForeColor="red" ControlToValidate="ddlDepartment" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="Department name is required" InitialValue="--Select A Department--"></asp:RequiredFieldValidator></td>

            </tr>
            <tr>
                <td style="padding: 20px" class="text-right">
                    <asp:Button ID="saveButton" CssClass="btn btn-default" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
                <td colspan="2" >
                    <asp:Button  ID="updateButton" CssClass="btn btn-primary" runat="server" Text="Update" />

                
                    &nbsp;

                
                    <asp:Button ID="deleteButton" CssClass="btn btn-danger" runat="server" Text="Delete" /></td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="msgLabel" runat="server" ></asp:Label>
                </td>
            </tr><tr>
                <td>
                    Update Or Delete Student
                </td>
                <td>
                    <asp:DropDownList ID="ddlupdateDelete" runat="server" OnSelectedIndexChanged="ddlupdateDelete_SelectedIndexChanged">
                        <asp:ListItem Text="--Select A Student"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
        </table>

    </fieldset>
</asp:Content>
