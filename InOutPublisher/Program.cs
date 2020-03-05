using System;
using Quartz;
using Topshelf;
using Topshelf.Quartz;

namespace InOutPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            
        }

        private static void Execute()
        {
            HostFactory.Run(x =>
            {
                x.Service<InOutService>(s =>
                {
                    s.WhenStarted(service => service.OnStart());
                    s.WhenStopped(service => service.OnStop());
                    s.ConstructUsing(() => new InOutService());

                    s.ScheduleQuartzJob(q =>
                        q.WithJob(() =>
                                JobBuilder.Create<MyJob>().Build())
                            .AddTrigger(() => TriggerBuilder.Create()
                                .WithCronSchedule("0 */1 * ? * *")
                                .Build()));
                });

                x
                    .DependsOnEventLog()
                    .StartAutomatically()
                    .EnableServiceRecovery(rc => rc.RestartService(1));

                x.SetServiceName("InOutProcessorService");
                x.SetDisplayName("InOutProcessorService");
                x.SetDescription("InOutProcessorService");
            });
        }
    }
}
