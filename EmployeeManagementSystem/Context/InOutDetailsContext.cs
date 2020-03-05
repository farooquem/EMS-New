using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.Context
{
    public partial class EmployeeManagementContext
    {
        public DataTable GetInOutDetails(DateTime fromDate, DateTime toDate, int employeeId)
        {
            var ds = new DataSet();
            var query = "SELECT e.EmployeeId,CONCAT(e.FirstName,' ',e.MiddleName,' ',e.LastName) as EmployeeName ,CONVERT(varchar(10),[OfficeDate],103) as [Date], " +
            " Replace(Replace(LTRIM(RIGHT(CONVERT(VARCHAR(20), [InTime], 100), 7)), 'PM', ' PM'), 'AM', ' AM')[InTime], Replace(Replace(LTRIM(RIGHT(CONVERT(VARCHAR(20), [OutTIme], 100), 7)), 'PM', ' PM'), 'AM', ' AM')[OutTime] " +
                                 " FROM [InOutDetails] t inner join Employee e on t.EmployeeId=e.Id WHERE t.[OfficeDate] >= '"+ fromDate.Date.ToString("yyyy-M-d") + "' AND t.[OfficeDate] <='" + toDate.Date.ToString("yyyy-M-d") + "'";
            
            if (employeeId > 0)
            {
                query += " and t.EmployeeId=" + employeeId;
            }
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }

        public DataTable GetOnlyEmployeeId()
        {
            var ds = new DataSet();
            var query = "select 'Select All' as EmployeeId, -1 as Id Union select EmployeeId,Id from Employee where IsActive=1";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }

        public DataTable GetOnlyEmployee()
        {
            var ds = new DataSet();
            var query = "select 'Select All' as Name, -1 as Id Union select CONCAT(FirstName,' ',LastName) as Name,Id from Employee  where IsActive=1";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
    }
}