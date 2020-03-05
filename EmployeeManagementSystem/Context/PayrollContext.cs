using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.Context
{
    public partial class EmployeeManagementContext
    {

        public DataTable GetPayEmployeeDetails(int employeeId)
        {
            var ds = new DataSet();
            var query = "SELECT s.EmployeeId,s.BasicSalary FROM salary s inner join employee e on e.Id=s.EmployeeId " +
                        "where e.IsActive=1 and e.DateOfLeaving is null  ";
            if (employeeId > 0)
            {
                query += " and s.EmployeeId=" + employeeId;
            }
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }

        public void SaveSalarySlip(int year, int month, string createdBy, int employeeId)
        {
            var data = GetPayEmployeeDetails(employeeId);
            data.Columns.Add("EPF", typeof(decimal));
            data.Columns.Add("CashInHand", typeof(decimal));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var basicSalary = Convert.ToInt32(data.Rows[i]["BasicSalary"]);
                var epf = (basicSalary * 12) / 100;
                var cashInHand = basicSalary - epf;
                data.Rows[i]["EPF"] = epf;
                data.Rows[i]["CashInHand"] = cashInHand;
            }

            data.AcceptChanges();
            InsertSalarySlip(year, month, createdBy, data);

        }

        private void InsertSalarySlip(int year, int month, string createdBy, DataTable dt)
        {
            var con = new SqlConnection(_connectionString);
            var query =
                "INSERT INTO [dbo].[SalarySlip]([EmployeeId],[FinancialYear],[FinancialMonth],[BasicSalary],[EPF],[CashInHand],[CreatedOn],[CreatedBy]) "
                + " VALUES({0},{1},{2},{3},{4},{5},GETDATE(),'{6}')";
            var cmd = new SqlCommand(query, con);
            con.Open();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var query1 = string.Format(query, dt.Rows[i]["EmployeeId"], year, month,
                    dt.Rows[i]["BasicSalary"],dt.Rows[i]["EPF"], dt.Rows[i]["CashInHand"], createdBy);

                cmd = new SqlCommand("DELETE FROM [dbo].[SalarySlip] WHERE [EmployeeId]=" + dt.Rows[i]["EmployeeId"] + " AND [FinancialYear]=" + year + " AND [FinancialMonth]= " + month, con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public DataTable GetPaySlip(int year, int month)
        {
            var ds = new DataSet();
            var query = "SELECT e.EmployeeId, CONCAT(FirstName,' ',LastName) as Name,s.BasicSalary,s.EPF,s.CashInHand,s.CreatedBy,s.CreatedOn FROM [dbo].SalarySlip s "
           + " inner join Employee e on s.EmployeeId = e.Id where s.FinancialYear = " + year + "  and s.FinancialMonth = "+ month+"; ";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }

        public void InsertSalary(int employeeId, int basicSalary, string createdBy)
        {
            var epf = (basicSalary * 12) / 100;
            var cashInHand = basicSalary - epf;
            var con = new SqlConnection(_connectionString);
            var query =
                "INSERT INTO [dbo].[Salary]([EmployeeId],[BasicSalary],[EPF],[CashInHand],[CreatedOn],[CreatedBy]) "
                + " VALUES({0},{1},{2},{3},GETDATE(),'{4}')";
            con.Open();

            var query1 = string.Format(query, employeeId, basicSalary, epf, cashInHand, createdBy);
            var cmd = new SqlCommand("DELETE FROM [dbo].[SalarySlip] WHERE [EmployeeId]=" + employeeId, con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}