using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.Context
{
    public partial class EmployeeManagementContext
    {
        public void AddEmployee(DataTable dt)
        {
            var con = new SqlConnection(_connectionString);
            var dol = string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["DateOfLeaving"])) ? "', null,'" : "','" + dt.Rows[0]["DateOfLeaving"] + "','";
            var query =
                "INSERT INTO [dbo].[Employee] ([EmployeeId],[FirstName],[MiddleName],[LastName],[DepartmentId],[Job_Title],[ContactNumber]," +
                "[Email],[Address],[DateOfBirth],[DateofJoining],[DateOfLeaving],[Gender],[CreatedOn],[CreatedBy],[IsActive])" +
                " VALUES ('" + dt.Rows[0]["EmployeeId"] + "','" + dt.Rows[0]["FirstName"] + "','" +
                dt.Rows[0]["MiddleName"] + "','" + dt.Rows[0]["LastName"]
                + "','" + dt.Rows[0]["DepartmentId"] + "','" + dt.Rows[0]["Job_Title"]
                + "','" + dt.Rows[0]["ContactNumber"] + "','" + dt.Rows[0]["Email"]
                + "','" + dt.Rows[0]["Address"] + "','" + dt.Rows[0]["DateOfBirth"]
                + "','" + dt.Rows[0]["DateofJoining"] + dol + dt.Rows[0]["Gender"] + "','" + dt.Rows[0]["CreatedOn"]
                + "','" + dt.Rows[0]["CreatedBy"] + "','" + dt.Rows[0]["IsActive"] + "') Select @@Identity";
            var cmd = new SqlCommand(query, con);
           

            con.Open();
          var id = (int)  cmd.ExecuteScalar();
          var query1 = "INSERT INTO [dbo].[User] ([EmployeeId],[Username],[Password],[IsActive],[CreatedOn],[CreatedBy]) " +
                       "VALUES ('" + id + "','" + string.Format("{0}.{1}", dt.Rows[0]["FirstName"], dt.Rows[0]["LastName"]) + "','" +
                       "Password@123',1,GETDATE(),'" + dt.Rows[0]["CreatedBy"] + "')";
            cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            con.Close();

            InsertSalary(id, Convert.ToInt32(dt.Rows[0]["BasicSalary"]), Convert.ToString( dt.Rows[0]["CreatedBy"]));
        }

        public void UpdateEmployee(DataTable dt, int id)
        {
            var dol = string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["DateOfLeaving"])) ? "null" : "'" + dt.Rows[0]["DateOfLeaving"] + "'";
            var con = new SqlConnection(_connectionString);
            var query = "UPDATE [dbo].[Employee] SET [FirstName] =  '" + dt.Rows[0]["FirstName"] + "'"
                        + ",[MiddleName] ='" + dt.Rows[0]["MiddleName"] + "'"
                        + " ,[LastName] ='" + dt.Rows[0]["LastName"] + "'"
                        + ",[DepartmentId] ='" + dt.Rows[0]["DepartmentId"] + "'"
                        + ",[Job_Title] ='" + dt.Rows[0]["Job_Title"] + "'"
                        + ",[ContactNumber] ='" + dt.Rows[0]["ContactNumber"] + "'"
                        + ",[Email] ='" + dt.Rows[0]["Email"] + "'"
                        + ",[Address] ='" + dt.Rows[0]["Address"] + "'"
                        + ",[DateOfBirth] ='" + dt.Rows[0]["DateOfBirth"] + "'"
                        + ",[DateofJoining] ='" + dt.Rows[0]["DateOfJoining"] + "'"
                        + ",[DateOfLeaving] =" + dol
                        + ",[Gender] ='" + dt.Rows[0]["Gender"] + "' "
                        + ",[IsActive] ='" + dt.Rows[0]["IsActive"] + "' WHERE ID=" + id;
            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            InsertSalary(id, Convert.ToInt32(dt.Rows[0]["BasicSalary"]), Convert.ToString(dt.Rows[0]["CreatedBy"]));
        }

        public string GetEmployeeId()
        {
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("EXEC [dbo].[GetEmployeeId]", con);
            con.Open();
            var employeeId = (string)cmd.ExecuteScalar();
            con.Close();
            return employeeId;
        }

        public DataTable GetEmployee(int employeeId)
        {
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter("select * from Employee where Id = " + employeeId, con);
            var ds = new DataSet();
            con.Open();
            adp.Fill(ds, "Employee");
            con.Close();
            return ds.Tables[0];
        }

        public DataTable GetEmployee(string employeeId)
        {
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter("select * from Employee where EmployeeId ='" + employeeId + "'", con);
            var ds = new DataSet();
            con.Open();
            adp.Fill(ds, "Employee");
            con.Close();
            return ds.Tables[0];
        }



        public DataTable GetAllEmployee()
        {
            var ds = new DataSet();
            const string query = "select e.Id,EmployeeId, CONCAT(FirstName,' ',MiddleName,' ',LastName) as Name,d.Name as Department," +
                                 "Job_Title,ContactNumber,Email,Address,DateOfBirth,DateOfJoining,DateOfLeaving,Gender, CASE e.IsActive WHEN 1 THEN 'Yes' ELSE 'No' End IsActive  from" +
                                 " Employee e left join Department d on e.DepartmentId = d.Id";
            var con = new SqlConnection(_connectionString);
            var adp = new SqlDataAdapter(query, con);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
    }
}