using System;
using System.Web.UI;
using EmployeeManagementSystem.Context;

namespace EmployeeManagementSystem
{
    public partial class InOutDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = Convert.ToString(Session["userId"]);
            if (!IsPostBack)
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    Response.Redirect("~/Login.aspx");
                }
                var context = new EmployeeManagementContext();
                ddlEmployee.DataSource = context.GetOnlyEmployeeId();
                ddlEmployee.DataTextField = "EmployeeId";
                ddlEmployee.DataValueField = "Id";
                ddlEmployee.DataBind();
                txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            try
            {
                var context = new EmployeeManagementContext();
                gvInOut.DataSource = context.GetInOutDetails(Convert.ToDateTime(txtFromDate.Text),
                    Convert.ToDateTime(txtToDate.Text),
                    Convert.ToInt32(ddlEmployee.SelectedValue));
                gvInOut.DataBind();
            }
            catch (Exception exception)
            {

            }
            
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            ddlEmployee.SelectedIndex = 0;
        }

        protected void btnGenerate_OnClick(object sender, EventArgs e)
        {
            EmployeeManagementContext context = new EmployeeManagementContext();
            context.GenerateInOut(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text),
                Convert.ToInt32(ddlEmployee.SelectedValue));
            ShowAlert("In/Out time generated for below date range");
        }

        private void ShowAlert(string message)
        {
            string script = "alert('" + message + "')";
            ScriptManager.RegisterStartupScript(this, GetType(),
                "ServerControlScript", script, true);
        }
    }
}