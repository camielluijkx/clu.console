using clu.console.library;

using System.Collections.Generic;

namespace clu.console.demo.net35
{
    class Program
    {
        private static void TestSomeLogging()
        {

        }

        private static void TestRandomLogging()
        {

        }

        static void Main(string[] args)
        {
            ConsoleHelper.Initialize(".NET 3.5.0");
            ConsoleHelper.ShowMenu(
                 new List<MenuItem>
                 {
                    new MenuItem(1, "Test some logging", TestSomeLogging),
                    new MenuItem(2, "Test random logging", TestSomeLogging),
                 });
        }
    }
}
