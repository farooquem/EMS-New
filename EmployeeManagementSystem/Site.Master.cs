using System;
using System.Web.UI;

namespace EmployeeManagementSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lnklogout_OnServerClick(object sender, EventArgs e)
        {
           Session.Abandon();
           Response.Redirect("~/Login.aspx");
        }
    }
}