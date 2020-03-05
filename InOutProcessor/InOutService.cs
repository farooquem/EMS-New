using System;
using System.Configuration;
using Quartz;

namespace InOutProcessor
{
   public class InOutService
    {
        public void OnStart()
        {

        }

        public void OnStop()
        {

        }
    }

    public class  MyJob : IJob
    {
        

        void IJob.Execute(IJobExecutionContext context)
        {
           

            Random random = new Random();
            TimeSpan start = TimeSpan.FromHours(7);
            TimeSpan end = TimeSpan.FromHours(11);
            int maxMinutes = (int)((end - start).TotalMinutes);

            for (int i = 0; i < 100; ++i)
            {
                int minutes = random.Next(maxMinutes);
                TimeSpan t = start.Add(TimeSpan.FromMinutes(minutes));
                Console.WriteLine("Run at " + Convert.ToDateTime(t.ToString()));
                // Do something with t...
            }
            Console.WriteLine("Run at " + DateTime.Now.ToString("dd-MM-yyyy hh:MM:ss"));
        }
    }
}
