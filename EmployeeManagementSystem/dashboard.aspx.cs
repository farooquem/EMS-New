using System;

namespace EmployeeManagementSystem
{
    public partial class dashboard : System.Web.UI.Page
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
            }
            if (DateTime.Now.Hour < 12)
            {
                lblGreeting.Text = "Good Morning " + userId;
            }
            else if (DateTime.Now.Hour < 17)
            {
                lblGreeting.Text = "Good Afternoon " + userId;
            }
            else
            {
                lblGreeting.Text = "Good Evening" + userId;
            }
        }
    }
}