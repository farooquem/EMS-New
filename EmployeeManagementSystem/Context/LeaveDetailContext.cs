using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Context
{
    public partial class EmployeeManagementContext
    {
        public DataTable GetLeaveDetails()
        {
            var ds = new DataSet();
            var query = "select l.Id,e.EmployeeId,CONCAT(e.FirstName,' ',e.LastName) as Name,FromDate,ToDate,NoOfDate,LeaveReason,CASE WHEN Approved=1 then 'Yes' else 'No' end as Approved,l.CreatedOn,l.CreatedBy  " +
           " from LeaveDetails l inner join Employee e on l.EmployeeId = e.Id Where l.IsDeleted=0 ";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }

        public DataTable GetLeaveDetails(string employeeId)
        {
            var ds = new DataSet();
            var query = "select l.* from LeaveDetails inner join  Employee on l.EmployeeId=e.Id where e.EmployeeId='" + employeeId + "' and Approved=0 ";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }

        public DataTable GetEmployeeName()
        {
            var ds = new DataSet();
            var query = "SELECT Id, CONCAT(FirstName,' ',MiddleName,' ',LastName) as Name FROM [dbo].[Employee] where IsActive=1 and DateOfLeaving is null ";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }

        public void InsertLeaveDetails(int id, string fromDate, string toDate, string reason, int noOfDays, string createdBy)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "INSERT INTO [dbo].[LeaveDetails] ([EmployeeId],[FromDate],[ToDate],[NoOfDate],[LeaveReason],[Approved],[CreatedOn],[CreatedBy]) " +
                " VALUES ( " + id + ",'" + fromDate + "','" + toDate + "'," + noOfDays + ",'" + reason + "',1,GETDATE(),'" + createdBy + "')";
            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteLeaveDetails(int id, bool isActive)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "UPDATE [dbo].[LeaveDetails] SET [IsDeleted] = '"+ isActive + "' WHERE ID=" + id;
            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}