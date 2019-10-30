<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add department.aspx.cs" Inherits="UniversityRegister.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function IsValid(source,args) {
            args.IsValid = (args.Value.length == 4 );
        }
    </script>
    <fieldset>
        <legend>Add Department</legend>

        <table class="nav-justified">
            <tr>
                <td class="text-right" style="font-size: medium; width: 200px"><strong>Department Name</strong></td>
                <td class="modal-sm" style="width: 569px">
                    <asp:TextBox ID="departmentNameTextBox" Width="541px" CssClass="form-control" runat="server" style="margin-left: 0"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="departmentNameTextBoxValidator" runat="server" ForeColor="red" ControlToValidate="departmentNameTextBox" Display="Dynamic" SetFocusOnError="True" ErrorMessage="Department name is required"></asp:RequiredFieldValidator></td>

            </tr>
            <tr>
                <td class="text-right" style="font-size: medium;width: 200px"><strong>Department Code</strong></td>
                <td class="modal-sm" style="width: 569px">
                    <asp:TextBox ID="departmentCodeTextBox" Width="541px" CssClass="form-control" runat="server"></asp:TextBox></td>
                <td>
                    <asp:CustomValidator ID="departmentCodeTextBoxValidator" runat="server" ErrorMessage="Department code should be 4 character" ForeColor="red" SetFocusOnError="True" Display="Dynamic" ValidateEmptyText="True"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td colspan="2" style="padding: 10px; " class="text-right">
                    <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="saveButton_Click" /></td>
                <td>
                    <asp:Label ID="msgLabel" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>

    </fieldset>
</asp:Content>
