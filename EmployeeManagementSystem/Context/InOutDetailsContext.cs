using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.UI.WebControls.Expressions;

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

        public DataTable GetAllEmployees(int employeeId)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "SELECT Id as EmployeeId FROM [Employee] Where IsActive = 1";

            if (employeeId > 0)
            {
                query += " and Id=" + employeeId;
            }

            var adp = new SqlDataAdapter(query, con);
            var ds = new DataSet();
            con.Open();
            adp.Fill(ds, "Employee");
            con.Close();
            return ds.Tables[0];
        }

        public string AddInOut(int employeeId, DateTime date, string intTime, string outTime)
        {

            var query =
                $" INSERT INTO [InOutDetails]([EmployeeId],[OfficeDate],[InTIme],[OutTime]) VALUES('{employeeId}','{date.ToShortDateString()}','{intTime}','{outTime}')";
            return query;
        }

        public string DeleteInOut(int employeeId, DateTime date)
        {
            var query = "DELETE FROM [InOutDetails] WHERE [EmployeeId]='" + employeeId + "' and [OfficeDate]='" +
                        date.ToShortDateString() + "'";
            return query;
        }


        public void GenerateInOut(DateTime fromDate, DateTime toDate, int employeeId)
        {
            var data = GetAllEmployees(employeeId);
            data.Columns.Add("Date", typeof(DateTime));
            data.Columns.Add("InTime", typeof(string));
            data.Columns.Add("OutTime", typeof(string));

            var date = fromDate;
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("", con);
            con.Open();
            while (toDate >= date)
            {
               

                for (var i = 0; i < data.Rows.Count; i++)
                {
                    cmd = new SqlCommand(DeleteInOut(Convert.ToInt32(data.Rows[i]["EmployeeId"]), date), con);
                    cmd.ExecuteNonQuery();
                    Thread.Sleep(1000);
                    var inTime = GetInTime();
                    Thread.Sleep(1000);
                    var outTime = GetOutTime();
                    cmd = new SqlCommand(AddInOut(Convert.ToInt32(data.Rows[i]["EmployeeId"]), date, inTime, outTime),
                        con);
                    cmd.ExecuteNonQuery();
                }
                date = date.AddDays(1);
            }
            con.Close();
        }

        public static string GetInTime()
        {
            var random = new Random();
            var start = TimeSpan.FromHours(9);
            var end = TimeSpan.FromHours(11);
            var maxMinutes = (int)((end - start).TotalMinutes);
            var minutes = random.Next(maxMinutes);
            var t = start.Add(TimeSpan.FromMinutes(minutes));
            return t.ToString();
        }

        public static string GetOutTime()
        {
            var random = new Random();
            var start = TimeSpan.FromHours(19);
            var end = TimeSpan.FromHours(21);
            var maxMinutes = (int)((end - start).TotalMinutes);
            var minutes = random.Next(maxMinutes);
            var t = start.Add(TimeSpan.FromMinutes(minutes));
            return t.ToString();
        }
    }
}