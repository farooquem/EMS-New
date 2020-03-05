using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InOutPublisher
{
    internal class MyContext
    {
        private readonly string _connectionString;
        public MyContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
        }

        public DataTable GetAllEmployees()
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "SELECT Id as EmployeeId FROM [Employee] Where IsActive = 1";
            var adp = new SqlDataAdapter(query, con);
            var ds = new DataSet();
            con.Open();
            adp.Fill(ds, "Employee");
            con.Close();
            return ds.Tables[0];
        }

        public void AddInOut(int employeeId, DateTime date, string intTime, string outTime)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                $" INSERT INTO[InOutDetails]([EmployeeId],[OfficeDate],[InTIme],[OutTime]) VALUES('{employeeId}','{date.ToShortDateString()}','{intTime}','{outTime}')"; 
            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
