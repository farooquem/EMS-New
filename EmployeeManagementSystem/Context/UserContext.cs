using System;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Context
{
    public partial class EmployeeManagementContext
    {
        public User Login(string username, string password)
        {
            var ds = new DataSet();
            var query = "select Username,EmployeeId, Password from [User] where username='" + username + "' and password='" + password + "'";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            var user = new User();
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                user.Username = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                user.EmployeeId = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeId"]);
            }
            return user;
        }

        public User UserExists(string username)
        {
            var ds = new DataSet();
            var query = "select Username,EmployeeId, Password from [User] where username='" + username + "'";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            var user = new User();
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                user.Username = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                user.EmployeeId = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeId"]);
                user.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
            }
            return user;
        }

        public void UpdateUser(User user)
        {
            var query = "Update [dbo].[User] Set Password='" + user.Password + "', ModifiedOn= GETDATE() " + " where EmployeeId='" + user.EmployeeId + "'";
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}