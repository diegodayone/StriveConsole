using System;

namespace StriveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Strive Console");

            var run = true;
            while (run)
            {
                var command = Console.ReadLine();
                run = CommandExecutor.Execute(command); //if quit or exit, run = false => quit
            }
        }
    }
}
