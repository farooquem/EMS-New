using System.Configuration;
using System.Data;

namespace EmployeeManagementSystem.Context
{
    public partial class EmployeeManagementContext
    {
        private readonly string _connectionString;
        public EmployeeManagementContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
        }
        public static DataTable GetGenderList()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add("M", "Male");
            dt.Rows.Add("F", "Female");
            dt.Rows.Add("U", "Universal");
            return dt;
        }


      
    }
}