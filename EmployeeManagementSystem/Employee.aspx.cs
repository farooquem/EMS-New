using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementSystem.Context;

namespace EmployeeManagementSystem
{
    public partial class Employee : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var emp = new EmployeeManagementContext();
                ddlDepartment.DataSource = emp.GetActiveDepartment();
                ddlDepartment.DataTextField = "Name";
                ddlDepartment.DataValueField = "Id";
                ddlDepartment.DataBind();
                ddlGender.DataSource = EmployeeManagementContext.GetGenderList();
                ddlGender.DataTextField = "Name";
                ddlGender.DataValueField = "Id";
                ddlGender.DataBind();
                BindData();
                SearchDataTable();
                SetStage(Stage.Load);
            }

        }
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var employeeId = gvEmployee.SelectedRow.Cells[2].Text;
            var context = new EmployeeManagementContext();
            var dt = context.GetEmployee(employeeId);
            hdnId.Value = Convert.ToString(dt.Rows[0]["Id"]);
            lblEmployeeId.Text = Convert.ToString(dt.Rows[0]["EmployeeId"]);
            txtFirstName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
            txtMiddleName.Text = Convert.ToString(dt.Rows[0]["MiddleName"]);
            txtLastName.Text = Convert.ToString(dt.Rows[0]["LastName"]);
            try
            {
                ddlDepartment.SelectedValue = Convert.ToString(dt.Rows[0]["DepartmentId"]);
            }
            catch(Exception) { }

            txtJobTitle.Text = Convert.ToString(dt.Rows[0]["Job_Title"]);
            txtContactNumber.Text = Convert.ToString(dt.Rows[0]["ContactNumber"]);
            txtEmail.Text = Convert.ToString(dt.Rows[0]["Email"]);
            txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
            txtdob.Text = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]).ToString("yyyy-MM-dd");
            txtdoj.Text = Convert.ToDateTime(dt.Rows[0]["DateOfJoining"]).ToString("yyyy-MM-dd");
            txtdol.Text = dt.Rows[0]["DateOfLeaving"] == DBNull.Value
                ? string.Empty
                : Convert.ToDateTime(dt.Rows[0]["DateOfLeaving"]).ToString("yyyy-MM-dd");
            ddlGender.SelectedValue = Convert.ToString(dt.Rows[0]["Gender"]);
            chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
           var dt1 = context.GetPayEmployeeDetails(Convert.ToInt32(hdnId.Value));
           if (dt1.Rows.Count > 0)
           {
               txtBasicSalary.Text = Convert.ToInt32(dt1.Rows[0]["BasicSalary"]).ToString();
           }

           SetStage(Stage.Edit);
        }

        private void BindData()
        {
            var emp = new EmployeeManagementContext();
            gvEmployee.DataSource = emp.GetAllEmployee();
            gvEmployee.DataBind();
        }

        protected void btnNew_OnClick(object sender, EventArgs e)
        {
            txtdoj.Text = DateTime.Now.ToString("yyyy-MM-dd");
            chkActive.Checked = true;
            SetStage(Stage.New);
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            var context = new EmployeeManagementContext();
            if (string.IsNullOrEmpty(hdnId.Value))
            {
                var dt = new DataTable();
                dt.Columns.AddRange(
                    new[]
                    {
                        new DataColumn("EmployeeId", typeof(string)),
                        new DataColumn("FirstName", typeof(string)),
                        new DataColumn("MiddleName", typeof(string)),
                        new DataColumn("LastName", typeof(string)),
                        new DataColumn("DepartmentId", typeof(int)),
                        new DataColumn("Job_Title", typeof(string)),
                        new DataColumn("ContactNumber", typeof(string)),
                        new DataColumn("Email", typeof(string)),
                        new DataColumn("Address", typeof(string)),
                        new DataColumn("DateOfBirth", typeof(DateTime)),
                        new DataColumn("DateofJoining", typeof(DateTime)),
                        new DataColumn("DateOfLeaving", typeof(DateTime)),
                        new DataColumn("Gender", typeof(string)),
                        new DataColumn("CreatedOn", typeof(DateTime)),
                        new DataColumn("CreatedBy", typeof(string)),
                        new DataColumn("IsActive", typeof(bool)),
                        new DataColumn("BasicSalary", typeof(int))
                    });
                var employeeId = context.GetEmployeeId();
                dt.Rows.Add(
                    employeeId,
                    txtFirstName.Text,
                    txtMiddleName.Text,
                    txtLastName.Text, ddlDepartment.SelectedValue,
                    txtJobTitle.Text,
                    txtContactNumber.Text,
                    txtEmail.Text,
                    txtAddress.Text,
                    txtdob.Text,
                    txtdoj.Text,
                    string.IsNullOrEmpty(txtdol.Text) ? null : txtdoj.Text,
                    ddlGender.SelectedValue,
                    DateTime.Now,
                    Session["userId"] ?? "Admin",
                    chkActive.Checked,
                    txtBasicSalary.Text
                );
                context.AddEmployee(dt);
                ShowAlert(" Employee Added");

            }
            else
            {
                var dt = new DataTable();
                dt.Columns.AddRange(
                    new[]
                    {
                        new DataColumn("EmployeeId", typeof(string)),
                        new DataColumn("FirstName", typeof(string)),
                        new DataColumn("MiddleName", typeof(string)),
                        new DataColumn("LastName", typeof(string)),
                        new DataColumn("DepartmentId", typeof(int)),
                        new DataColumn("Job_Title", typeof(string)),
                        new DataColumn("ContactNumber", typeof(string)),
                        new DataColumn("Email", typeof(string)),
                        new DataColumn("Address", typeof(string)),
                        new DataColumn("DateOfBirth", typeof(DateTime)),
                        new DataColumn("DateofJoining", typeof(DateTime)),
                        new DataColumn("DateOfLeaving", typeof(DateTime)),
                        new DataColumn("Gender", typeof(string)),
                        new DataColumn("CreatedOn", typeof(DateTime)),
                        new DataColumn("CreatedBy", typeof(string)),
                        new DataColumn("IsActive", typeof(bool)),
                        new DataColumn("BasicSalary", typeof(int)) 
                    });
                dt.Rows.Add(
                    lblEmployeeId.Text,
                    txtFirstName.Text,
                    txtMiddleName.Text,
                    txtLastName.Text, ddlDepartment.SelectedValue,
                    txtJobTitle.Text,
                    txtContactNumber.Text,
                    txtEmail.Text,
                    txtAddress.Text,
                    txtdob.Text,
                    txtdoj.Text,
                    string.IsNullOrEmpty(txtdol.Text) ? null : txtdoj.Text,
                    ddlGender.SelectedValue,
                    DateTime.Now,
                    Session["userId"] ?? "Admin",
                    chkActive.Checked,
                     txtBasicSalary.Text
                );
                context.UpdateEmployee(dt, Convert.ToInt32(hdnId.Value));
                ShowAlert(" Employee Updated");
            }

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
            switch (stage)
            {
                case Stage.Load:
                    btnNew.Visible = true;
                    ClearField();
                    ShowField(false);
                    BindData();
                    gvEmployee.SelectedIndex = -1;
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

        protected void cusCustom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = DateTime.TryParse(args.Value, out _);
        }

        private void ShowAlert(string message)
        {
            string script = "alert('" + message + "')";
            ScriptManager.RegisterStartupScript(this, GetType(),
                "ServerControlScript", script, true);
        }

        private void ClearField()
        {
            lblEmployeeId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            ddlDepartment.SelectedIndex = 0;
            txtJobTitle.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtdob.Text = string.Empty;
            txtdoj.Text = string.Empty;
            txtdol.Text = string.Empty;
            ddlGender.SelectedIndex = 0;
            chkActive.Checked = false;
            hdnId.Value = string.Empty;
        }

        private void ShowField(bool show)
        {
            controls.Visible = show;
        }

        private void SearchDataTable()
        {
            var dt= new DataTable();
            dt.Columns.Add("Key", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            dt.Rows.Add("Employee Id", "EmployeeId");
            dt.Rows.Add("Name", "Name");
            dt.Rows.Add("Department", "Department");
            dt.Rows.Add("Job Title", "Job_Title");
                dt.Rows.Add("Contact Number", "ContactNumber");
            dt.Rows.Add("Email", "Email");
            dt.Rows.Add("Address", "Address");
            dt.Rows.Add("Gender", "Gender");
            //ddlFilter.DataSource = dt;
            //ddlFilter.DataTextField = "Key";
            //ddlFilter.DataValueField = "Value";
            //ddlFilter.DataBind();
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public enum Stage
    {
        Load=0,
        New=1,
        Edit=2
    }
}