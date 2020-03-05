using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.Context
{
    public partial class EmployeeManagementContext
    {
        public DataTable GetActiveDepartment()
        {
            var ds = new DataSet();
            const string query = "SELECT ID,Name FROM Department where IsActive=1";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];

        }

        public DataTable GetAllDepartment()
        {
            var ds = new DataSet();
            const string query = "SELECT ID,Name, CASE IsActive when 1 then 'Yes' else 'No' end IsActive,CreatedBy,CreatedOn FROM Department";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];

        }

        public DataTable GetDepartment(string department)
        {
            var ds = new DataSet();
            string query = "SELECT ID,Name, CASE IsActive when 1 then 'Yes' else 'No' end IsActive,CreatedBy,CreatedOn FROM Department where Name = '" + department + "'";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];

        }

        public void AddDepartment(string department, bool isActive, string user)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "INSERT INTO [dbo].[Department] ([Name],[IsActive],[CreatedOn],[CreatedBy]) VALUES ('" + department + "','" + isActive + "', GETDATE(),'" + user + "')";
            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool DepartmentExists(string department)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "SELECT Count(1)  FROM [dbo].[Department]  where Name ='" + department + "'";
            var cmd = new SqlCommand(query, con);
            con.Open();
            var value = (int)cmd.ExecuteScalar();
            con.Close();
            return value > 0;
        }

        public bool DepartmentExists(string department, int id)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "SELECT Count(1)  FROM [dbo].[Department]  where Name ='" + department + "' AND Id <>" + id;
            var cmd = new SqlCommand(query, con);
            con.Open();
            var value = (int)cmd.ExecuteScalar();
            con.Close();
            return value > 0;
        }

        public void UpdateDepartment(string department, bool isActive, int id)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "UPDATE [dbo].[Department] SET [Name] = '" + department + "',[IsActive] = '" + isActive + "' where Id=" + id;
            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}