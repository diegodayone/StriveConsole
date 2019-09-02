using System;
using System.Collections.Generic;

namespace StriveConsole
{
    class Program
    {
        static void TripleLoop(int[] array)
        {
            var sum = 0; //<- 1
            for (var i = 0; i < array.Length; i++) //N 
                for (var j = array.Length; j >= 0; j--) //N
                    for (var k = array.Length; k >= 0; k--) //N
                        sum += array[i];

            //O(n) = n^3
        }
        static void DoubleLoop(int[] array)
        {
            var sum = 0; //<- 1
            for (var i = 0; i < array.Length; i++) //N 
                for (var j = array.Length; j >= 0; j--) //N
                    sum += array[i];

            //O(n) = n^2
        }
        static int CalculateLength(int[] array) => array.Length; //<- 1
        static double CalculateArrayAverage(int[] array)
        {
            var sum = 0; //1
            foreach(var item in array) //N
                sum += item;

            var max = 0; //1
            foreach(var item in array) //N
                if (item > max) max = item;

            return sum / array.Length; //1
            //O(n) ==> 3 + 2 * N ==> N
        }

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
