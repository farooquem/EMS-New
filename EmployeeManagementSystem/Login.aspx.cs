using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementSystem.Context;

namespace EmployeeManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void BtnLogin_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
               ShowAlert("Enter Username");
               return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowAlert("Enter Password");
                return;
            }

            EmployeeManagementContext emp = new EmployeeManagementContext();
            var result = emp.Login(txtUsername.Text, txtPassword.Text);
            if (result.EmployeeId != 0)
            {
                Session["userId"] = result.Username;
                Session["employeeId"] = result.EmployeeId;
                Response.Redirect("dashboard.aspx");
            }
            else
            {
                ShowAlert("Invalid Username/Password");
                return;

            }
        }

        private void ShowAlert(string message)
        {
            string script = "alert('"+ message+"')";
            ScriptManager.RegisterStartupScript(this, GetType(),
                "ServerControlScript", script, true);
        }

        protected void BtnResetPassword_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}