using clu.logging.log4net;

using log4net;

using System;
using System.Threading.Tasks;

namespace clu.console
{
    // [TODO] arrange log4net config is added by installing nuget package
    class Program
    {
        private static void Initialize()
        {
            Console.WriteLine("Initializing...");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*******************        TFS Console       *******************");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("\t\t\t\t\t\t\t\t");
            Console.WriteLine(@"                 _________ .____     ____ ___                   ");
            Console.WriteLine(@"                 \_   ___ \|    |   |    |   \                  ");
            Console.WriteLine(@"                 /    \  \/|    |   |    |   /                  ");
            Console.WriteLine(@"                 \     \___|    |___|    |  /                   ");
            Console.WriteLine(@"                  \______  /_______ \______/                    ");
            Console.WriteLine(@"                         \/        \/                           ");
            Console.WriteLine("\t\t\t\t\t\t\t\t");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void DoSomethingNormal()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter something normal");
            string something = Console.ReadLine();
            Console.WriteLine($"You entered: {something}");
        }

        private static void DoSomethingSpecial()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter something special");
            string something = Console.ReadLine();
            Console.WriteLine($"You entered: {something}");
        }

        private async static Task TestLoggingAsync()
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

        private static void TestLogging()
        {
            TestLoggingAsync().Wait();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Hello {0}, what would you like to do?", Environment.UserName);

            char choice = ' ';
            while (choice != '0')
            {
                Console.WriteLine("");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("[1] Do something normal");
                Console.WriteLine("[2] Test some logging");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[!] Do something special <-- You want this option");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                choice = consoleKey.KeyChar;

                if (choice == '1')
                {
                    DoSomethingNormal();
                }
                if (choice == '2')
                {
                    TestLogging();
                }
                else if (choice == '!')
                {
                    DoSomethingSpecial();
                }
            }
        }

        static void Main(string[] args)
        {
            Initialize();
            ShowMenu();
        }
    }
}
