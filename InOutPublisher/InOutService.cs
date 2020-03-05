using System;
using System.Threading;
using Quartz;

namespace InOutPublisher
{
  public  class InOutService
    {
        public void OnStart()
        {

        }

        public void OnStop()
        {

        }
    }

  public class MyJob : IJob
  {

      void IJob.Execute(IJobExecutionContext context)
      {
          MyContext context1 = new MyContext();

          var data = context1.GetAllEmployees();
          data.Columns.Add("Date", typeof(DateTime));
          data.Columns.Add("InTime", typeof(string));
          data.Columns.Add("OutTime", typeof(string));

          var date = DateTime.Now.AddDays(-1);
          for (var i = 0; i < data.Rows.Count; i++)
          {
              var inTime = GetInTime();
              Thread.Sleep(1000);
              var outTime = GetOutTime();
              context1.AddInOut(Convert.ToInt32(data.Rows[i]["EmployeeId"]), date, inTime, outTime );
              Thread.Sleep(1000);
          }
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
          var start = TimeSpan.FromHours(18);
          var end = TimeSpan.FromHours(20);
          var maxMinutes = (int)((end - start).TotalMinutes);
          var minutes = random.Next(maxMinutes);
          var t = start.Add(TimeSpan.FromMinutes(minutes));
          return t.ToString();
      }
    }
}
