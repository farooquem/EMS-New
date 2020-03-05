<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="EmployeeManagementSystem.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
        <div>
            <div class="card custom-card">
                <div class="card-header">
                    <h3>Login</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <asp:Label runat="server" >Username</asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUsername" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" >Password</asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" ></asp:TextBox>
                       
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" ID="BtnLogin" class="btn btn-primary rounded-0" Text="Login" OnClick="BtnLogin_OnClick" />
                        <asp:Button runat="server" ID="BtnResetPassword" class="btn btn-primary rounded-0" Text="Reset Password" OnClick="BtnResetPassword_OnClick" />
                    </div>

                </div>
            </div>
        </div>
   </asp:Content>