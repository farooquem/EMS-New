using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementSystem.Context;

namespace EmployeeManagementSystem
{
    public partial class payroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            selected_tab.Value = ((HiddenField) Page.FindControl(selected_tab.UniqueID)).Value;
            if (!IsPostBack)
            {
                var years = new[] {DateTime.Now.Year - 1, DateTime.Now.Year};
                ddlYear.DataSource = years;
                ddlYear.DataBind();
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlViewYear.DataSource = years;
                ddlViewYear.DataBind();
                ddlViewYear.SelectedValue = DateTime.Now.Year.ToString();
                var months = Enumerable.Range(1, 12).Select(i => new { I = i, M = DateTimeFormatInfo.InvariantInfo.GetMonthName(i) });
                ddlMonth.DataSource = months;
                ddlMonth.DataTextField = "M";
                ddlMonth.DataValueField = "I";
                ddlMonth.DataBind();

                ddlViewMonth.DataSource = months;
                ddlViewMonth.DataTextField = "M";
                ddlViewMonth.DataValueField = "I";
                ddlViewMonth.DataBind();
                var context = new EmployeeManagementContext();
               ddlEmployee.DataSource = context.GetOnlyEmployee();
               ddlEmployee.DataTextField = "Name";
               ddlEmployee.DataValueField = "Id";
               ddlEmployee.DataBind();
               ddlEmployee.SelectedIndex = 0;
            }
        }

        protected void btnGenerate_OnClick(object sender, EventArgs e)
        {
          var context= new EmployeeManagementContext();
          context.SaveSalarySlip(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue),
              string.IsNullOrEmpty(Convert.ToString(Session["userId"]))
                  ? "Admin"
                  : Convert.ToString(Session["userId"]),Convert.ToInt32(ddlEmployee.SelectedValue));
            ShowAlert(" Pay slip generated for the selected month");
        }

        private void ShowAlert(string message)
        {
            string script = "alert('" + message + "')";
            ScriptManager.RegisterStartupScript(this, GetType(),
                "ServerControlScript", script, true);
        }

        protected void BtnView_OnClick(object sender, EventArgs e)
        {
            var context = new EmployeeManagementContext();
           var dt = context.GetPaySlip(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
            gvpaySlip.DataSource = dt;
            gvpaySlip.DataBind();
        }
    }
}