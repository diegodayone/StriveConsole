using System;
using System.Collections.Generic;

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
                //var key = Console.ReadKey();
                //switch (key.Key)
                //{
                //    case ConsoleKey.UpArrow:
                //        // get from the history and replace current command
                //        // keep track of the history index (like how many time I pressed the UpArrow key)
                //        break;
                //    case ConsoleKey.Backspace:
                //        // remove from command last char
                //        break;
                //    case ConsoleKey.Enter:
                //        //CommandExecutor.Execute(command); 
                //        // reset the command
                //        break;
                //    default:
                //        //currentCommand += key.KeyChar
                //        break;
                //}
                run = CommandExecutor.Execute(command); //if quit or exit, run = false => quit
            }
        }
    }
}
