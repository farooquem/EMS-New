using System;
using System.Web.UI;
using EmployeeManagementSystem.Context;

namespace EmployeeManagementSystem
{
    public partial class Department : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                SetStage(Stage.Load);
            }
        }

        private void SetStage(Stage stage)
        {
            btnSave.Visible = false;
            btnNew.Visible = false;
            switch (stage)
            {
                case Stage.Load:
                    btnNew.Visible = true;
                    ClearField();
                    ShowField(false);
                    BindData();
                    gvDepartment.SelectedIndex = -1;
                    break;
                case Stage.New:
                    btnSave.Visible = true;
                    btnSave.Text = "Save";
                    ShowField(true);
                    break;
                case Stage.Edit:
                    btnSave.Visible = true;
                    btnSave.Text = "Update";
                    ShowField(true);
                    break;
            }
        }

        private void ShowAlert(string message)
        {
            var script = "alert('" + message + "')";
            ScriptManager.RegisterStartupScript(this, GetType(),
                "ServerControlScript", script, true);
        }

        private void ClearField()
        {
            txtDepartment.Text = string.Empty;
            chkActive.Checked = false;
            hdnId.Value = string.Empty;
        }

        private void ShowField(bool show)
        {
            controls.Visible = show;
        }

        private void BindData()
        {
            var emp = new EmployeeManagementContext();
            gvDepartment.DataSource = emp.GetAllDepartment();
            gvDepartment.DataBind();
        }

        protected void btnNew_OnClick(object sender, EventArgs e)
        {
            chkActive.Checked = true;
            SetStage(Stage.New);
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            var context = new EmployeeManagementContext();
            if (string.IsNullOrEmpty(hdnId.Value))
            {
                if (context.DepartmentExists(txtDepartment.Text.Trim()))
                {
                    ShowAlert(" Department already present");
                    return;
                }
                context.AddDepartment(txtDepartment.Text, chkActive.Checked,  
                    Session["userId"] == null ? "Admin" : Convert.ToString(Session["userId"]));
                ShowAlert(" Department Added");

            }
            else
            {
                if (context.DepartmentExists(txtDepartment.Text.Trim(), Convert.ToInt32(hdnId.Value)))
                {
                    ShowAlert(" Department already present");
                    return;
                }

                context.UpdateDepartment(txtDepartment.Text, chkActive.Checked,
                    Convert.ToInt32(hdnId.Value));
                ShowAlert(" Department Updated");
            }

            BindData();

            SetStage(Stage.Load);
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            SetStage(Stage.Load);
        }

        protected void gvDepartment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            txtDepartment.Text = gvDepartment.SelectedRow.Cells[2].Text;
            var context = new EmployeeManagementContext();
            var dt = context.GetDepartment(txtDepartment.Text);
            if (dt.Rows.Count > 0)
            {
                hdnId.Value = Convert.ToString(dt.Rows[0]["Id"]);
                txtDepartment.Text = Convert.ToString(dt.Rows[0]["Name"]);
                chkActive.Checked = Convert.ToString(dt.Rows[0]["IsActive"]) == "Yes";
            }

            SetStage(Stage.Edit);
        }
    }
}