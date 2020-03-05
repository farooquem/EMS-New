using System;
using System.Web.UI;
using EmployeeManagementSystem.Context;

namespace EmployeeManagementSystem
{
    public partial class ResetPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
           Response.Redirect("~/Login.aspx");
        }

        protected void btnChangePassword_OnClick(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim().Length < 8)
            {
                ShowAlert("new password minimum length should be 8 character");
                return;
            }
            else if (txtConfirmPassword.Text.Trim().Length < 8)
            {
                ShowAlert("confirm password minimum length should be 8 character");
                return;
            }
            else if (txtNewPassword.Text.Trim() == txtCurrentPassword.Text.Trim())
            {
                ShowAlert("New password should be different then old password");
                return;
            }

            var context = new EmployeeManagementContext();
            var user = context.UserExists(txtUsername.Text.Trim());
            if (string.IsNullOrEmpty(user.Username))
            {
                ShowAlert("No user exists");
                return;
            }
            else if (user.Password != txtCurrentPassword.Text.Trim())
            {
                ShowAlert("current password does not match");
                return;
            }

            user.Password = txtNewPassword.Text.Trim();
            user.ModifiedOn = DateTime.Now;
            context.UpdateUser(user);
            Response.Redirect("~/Login.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        private void ShowAlert(string message)
        {
            var script = "alert('" + message + "')";
            ScriptManager.RegisterStartupScript(this, GetType(),
                "ServerControlScript", script, true);
        }
    }
}