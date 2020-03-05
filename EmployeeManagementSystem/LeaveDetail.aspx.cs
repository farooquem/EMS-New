using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementSystem.Context;

namespace EmployeeManagementSystem
{
    public partial class LeaveDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var emp = new EmployeeManagementContext();
                ddlEmployeeName.DataSource = emp.GetEmployeeName();
                ddlEmployeeName.DataTextField = "Name";
                ddlEmployeeName.DataValueField = "Id";
                ddlEmployeeName.DataBind();
                BindData();
                SetStage(Stage.Load);
            }

        }

        protected void gvLeave_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var employeeId = gvLeave.SelectedRow.Cells[2].Text;
            var approved = gvLeave.SelectedRow.Cells[8].Text;
            if (approved == "Yes")
            {
                gvLeave.SelectedIndex = -1;
                SetStage(Stage.Load);
                return;
            }

            var context = new EmployeeManagementContext();
            var data = context.GetLeaveDetails(employeeId);
            if (data.Rows.Count == 0)
            {
                ShowAlert("No Data");
                SetStage(Stage.Load);
            }
            else
            {
                hdnId.Value = Convert.ToString(data.Rows[0]["Id"]);
                txtFromDate.Text = Convert.ToDateTime(data.Rows[0]["FromDate"]).ToString("yyyy-MM-df");
                txtFromDate.Text = Convert.ToDateTime(data.Rows[0]["toDate"]).ToString("yyyy-MM-df");
                ddlEmployeeName.SelectedValue = Convert.ToString(data.Rows[0]["EmployeeId"]);
                txtReason.Text = Convert.ToString(data.Rows[0]["Reason"]);
                SetStage(Stage.Edit);
            }
        }

        protected void btnNew_OnClick(object sender, EventArgs e)
        {
            SetStage(Stage.New);
        }

        private void ShowAlert(string message)
        {
            string script = "alert('" + message + "')";
            ScriptManager.RegisterStartupScript(this, GetType(),
                "ServerControlScript", script, true);
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            var from = new DateTime();
            var to = new DateTime();
            try
            {
                from = DateTime.Parse(txtFromDate.Text);
                to = DateTime.Parse(txtToDate.Text);
            }
            catch (Exception)
            {
                ShowAlert("Enter valid date");
                return;
            }

            var noOfDays = to.Subtract(from);

            if (noOfDays.Days < 0)
            {
                ShowAlert("To date cannot be more than from date");
                return;
            }

            var context = new EmployeeManagementContext();
            context.InsertLeaveDetails(Convert.ToInt32(ddlEmployeeName.SelectedValue), txtFromDate.Text,
                txtToDate.Text,
                txtReason.Text,
                noOfDays.Days + 1, string.IsNullOrEmpty(Convert.ToString(Session["userId"]))
                    ? "Admin"
                    : Convert.ToString(Session["userId"]));
            ShowAlert(" Leaves Added");


            BindData();

            SetStage(Stage.Load);
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            SetStage(Stage.Load);
        }

        private void SetStage(Stage stage)
        {
            btnSave.Visible = false;
            btnNew.Visible = false;
            chkApprove.Visible = false;
            switch (stage)
            {
                case Stage.Load:
                    btnNew.Visible = true;
                    ClearField();
                    ShowField(false);
                    BindData();
                    gvLeave.SelectedIndex = -1;
                    break;
                case Stage.New:
                    btnSave.Visible = true;
                    btnSave.Text = "Save";
                    ShowField(true);
                    break;
                case Stage.Edit:
                    btnSave.Visible = true;
                    btnSave.Text = "Update";
                    chkApprove.Visible = true;
                    ShowField(true);
                    break;
            }
        }

        private void ShowField(bool show)
        {
            controls.Visible = show;
        }

        private void ClearField()
        {
            ddlEmployeeName.SelectedValue = null;
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtReason.Text = string.Empty;
        }

        private void BindData()
        {
            var emp = new EmployeeManagementContext();
            gvLeave.DataSource = emp.GetLeaveDetails();
            gvLeave.DataBind();
        }

        protected void gvLeave_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var context = new EmployeeManagementContext();
            context.DeleteLeaveDetails(Convert.ToInt32(e.Values[0]), true);
            SetStage(Stage.Load);
        }
    }
}