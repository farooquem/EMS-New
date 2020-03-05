<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="EmployeeManagementSystem.ResetPassword" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="filt" style="margin-top: 20px" class="container-fluid">
    <div ID="controls" runat="server">
        <div class="row">
        <div class="col-sm-12 form-group">
            <asp:Label runat="server" ID="lblUsername" CssClass="control-label">Username</asp:Label>
            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="username" ForeColor="Red" ControlToValidate="txtUsername" ErrorMessage="Enter username" />
        </div>
        </div>
        <div class="row">
        <div class="col-sm-12 form-group">
            <asp:Label runat="server" ID="lblCurrentPassword" CssClass="control-label">Current Password</asp:Label>
            <asp:TextBox runat="server" TextMode="Password" ID="txtCurrentPassword" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="currentPassword" ForeColor="Red" ControlToValidate="txtCurrentPassword" ErrorMessage="Enter password" />
        </div>
            </div>
        <div class="row">
        <div class="col-sm-12 form-group">
            <asp:Label runat="server" ID="lblNewPassword" CssClass="control-label">New Password</asp:Label>
            <asp:TextBox runat="server" TextMode="Password" ID="txtNewPassword" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="newPassword" ForeColor="Red" ControlToValidate="txtNewPassword" ErrorMessage="Enter new password" />
        </div>
            </div>
        <div class="row">
        <div class="col-sm-12 form-group">
            <asp:Label runat="server" ID="lblConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
            <asp:TextBox runat="server"  TextMode="Password" ID="txtConfirmPassword" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="confirmPassword1" ForeColor="Red"
                                        ControlToValidate="txtConfirmPassword" ErrorMessage="Enter confirm password" />

            <asp:CompareValidator runat="server" ID="confirmPassword" ForeColor="Red" ControlToValidate="txtConfirmPassword"
                                  ControlToCompare="txtNewPassword"
                                        ErrorMessage="No Match" 
                                        ToolTip="Password must be the same" />
        </div>
        </div>
        <div class="row">
        <div class="col-sm-12 form-group">
            <asp:Button runat="server" Text="Change Password" ID="btnChnagePassword" CssClass="btn btn-danger" OnClick="btnChangePassword_OnClick" />
            <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-primary" OnClick="btnReset_OnClick" OnClientClick="return cleanForm();" CausesValidation="False" />
            <asp:Button runat="server" Text="Back to Login" CssClass="btn btn-default" ID="btnLogin" OnClick="btnLogin_OnClick" CausesValidation="False" />
        </div>
            </div>
    </div>
    </div> 
    <script type="text/javascript">
               function cleanForm() {

                   document.forms[0].reset();
                   for (var i = 0; i < Page_Validators.length; i++) {
                       Page_Validators[i].style.visibility = 'hidden';
                   }
                   return true;
               }
           </script>
    </asp:Content>