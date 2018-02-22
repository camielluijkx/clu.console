using System;

namespace clu.console
{
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
            Console.WriteLine(@"                                $$$$$$$$$$$                     ");
            Console.WriteLine(@"                 ?????        $$$$$$$$ZZZ$$$                    ");
            Console.WriteLine(@"              ~?++==++?I    7$$$$$$$$$$Z???Z$                   ");
            Console.WriteLine(@"             ~?+==~~~=+I$Z 777$$$$$$$  +OOOOO$                  ");
            Console.WriteLine(@"             ??+=        $77777$$$I     $ZZZZZ                  ");
            Console.WriteLine(@"             7I?        II777777?       77$$$$                  ");
            Console.WriteLine(@"              ~77      +IIIII777         777777                 ");
            Console.WriteLine(@"               II~  =IIIIIIIIIZZ        III777                  ");
            Console.WriteLine(@"                77IIIIIIIIII   77II?   IIIIII                   ");
            Console.WriteLine(@"                   7IIIII        $777777777     (TM)            ");
            Console.WriteLine(@"                                                                ");
            Console.WriteLine(@"     Microsoft (R) Visual Studio (R) Team Foundation Server     ");
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

        private static void ShowMenu()
        {
            Console.WriteLine("Hello {0}, what would you like to do?", Environment.UserName);

            char choice = ' ';
            while (choice != '0')
            {
                Console.WriteLine("");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("[1] Do something normal");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[!] Do something special <-- You want this option");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                choice = consoleKey.KeyChar;

                if (choice == '1')
                {
                    DoSomethingNormal();
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
