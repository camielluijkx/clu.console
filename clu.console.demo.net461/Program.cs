using clu.console.library;
using clu.logging.baconipsum;
using clu.logging.log4net;

using log4net;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clu.console.demo.net461
{
    class Program
    {
        private async static Task TestSomeLoggingAsync()
        {
            GlobalContext.Properties["correlationId"] = Guid.NewGuid();

            try
            {
                await Log4netLogger.LogDebugAsync("some debug message");
                await Log4netLogger.LogErrorAsync("some error message");
                await Log4netLogger.LogFatalAsync("some fatal message");
                await Log4netLogger.LogInformationAsync("some info message");
                await Log4netLogger.LogWarningAsync("some warning message");

                await Log4netLogger.LogInformationAsync("some stupid password");

                //throw new Exception("some exception occurred");

                await Log4netLogger.LogErrorAsync("kaboom!", new ApplicationException("The application exploded"));
            }
            catch (Exception ex)
            {
                await Log4netLogger.LogErrorAsync("Error trying to do something", ex);
            }
        }

        private static void TestSomeLogging()
        {
            TestSomeLoggingAsync().Wait();
        }

        private async static Task TestRandomLoggingAsync()
        {
            GlobalContext.Properties["correlationId"] = Guid.NewGuid();

            try
            {
                var ipsum = await BaconIpsumClient.GetAsync();

                var random = new Random();

                var dice = random.Next(1, 7);

                switch (dice)
                {
                    case 1:
                        await Log4netLogger.LogDebugAsync(ipsum);
                        break;
                    case 2:
                        await Log4netLogger.LogErrorAsync(ipsum);
                        break;
                    case 3:
                        await Log4netLogger.LogFatalAsync(ipsum);
                        break;
                    case 4:
                        await Log4netLogger.LogInformationAsync(ipsum);
                        break;
                    case 5:
                        await Log4netLogger.LogWarningAsync(ipsum);
                        break;
                    case 6:
                        await Log4netLogger.LogErrorAsync("bad luck", new Exception("no meat today"));
                        break;
                }
            }
            catch (Exception ex)
            {
                await Log4netLogger.LogErrorAsync("Error trying to do something", ex);
            }
        }

        private static void TestRandomLogging()
        {
            for (var i = 0; i < 100; i++)
            {
                TestRandomLoggingAsync().Wait();
            }
        }

        static void Main(string[] args)
        {
            ConsoleHelper.Initialize(".NET 4.6.1");
            ConsoleHelper.ShowMenu(
                new List<MenuItem>
                {
                    new MenuItem(1, "Test some logging", TestSomeLogging),
                    new MenuItem(2, "Test random logging", TestSomeLogging),
                });
        }
    }
}
