using System.Configuration;

namespace InOutProcessor
{
   class MyContext
    {
        private readonly string _connectionString;
        public MyContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
        }
    }
}
