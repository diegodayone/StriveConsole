using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StriveConsole
{
    class Program
    {
        static long EuclidGCD(long X, long Y)
        {
            Console.WriteLine("X = " + X.ToString().Length + " ==> Y = " + Y.ToString().Length);
            var numberOfIterations = 0;
            while (X != 0 && Y != 0)
            {
                numberOfIterations++;

                Console.WriteLine("X = " + X + ", Y = " + Y);
                if (X > Y) X %= Y;
                else Y %= X;
            }

            Console.WriteLine("GDC = " + (X == 0 ? Y : X) + " --> required iterations: " + numberOfIterations); 

            if (X == 0) return Y;
            return X;
        }

        static long EuclidGCDInShort(long X, long Y)
        {
            // O(n) = log10(N) ~ number of digit in a number
            while (X != 0 && Y != 0) // <- N has sort of 20 digits, we'll take something like steps
            {
                if (X > Y) X %= Y;
                else Y %= X;
            }

            return X == 0 ? Y : X;
        }

        static int RecursionSomething(int i)
        {
            if (i == 0) return -1;
            return RecursionSomething(i--);
        }

        static long EuclidGCDRecursive(long X, long Y)
        {
            Console.WriteLine("X = " + X + ", Y = " + Y);
            if (X == 0) return Y; //checks if we reached the end of the algorthm
            if (Y == 0) return X;

            //triggers again the same method, changing the params
            return X > Y ? EuclidGCDRecursive(X % Y, Y) : EuclidGCDRecursive(X, Y % X);
        }

        static long gcd(long X, long Y) => 
                X == 0 ? Y : 
                X > Y ? gcd(X % Y, Y) 
                : gcd(Y % X, X);

        static string[] BubbleSortStringEdition(string[] array)
        {
            var numberOfIterations = 0;

            for (var j = 0; j < array.Length - 1; j++)
                for (var i = 0; i < array.Length - 1; i++)
                {
                    numberOfIterations++;
                    if (String.Compare(array[i], array[i+1]) > 0)
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }

            Console.WriteLine(numberOfIterations);

            return array;
        }

        static void QuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                //Select the Pivot Point
                var i = QuickSortPartition(array, start, end);
                //Console.WriteLine("Selected Pivot ["+start + "-" + end + "] = " + i);

                //Execute on the first part of the array
                QuickSort(array, start, i - 1);
                //Execute on the second part
                QuickSort(array, i + 1, end);
            }
        }

        static int QuickSortPartition(int[] array, int start, int end)
        {
            int temp;
            int p = array[end];
            int i = start - 1;

            //Console.WriteLine("QuickSort on [" + start + "] -> " + end);
            //Console.WriteLine("---------------------------------------");
            for (var j = start; j <= end - 1; j++)
            {
                if (array[j] <= p)
                {
              //      Console.WriteLine("Swapping array[" + j + "]" + array[j] + " -> " + p);
                    i++;
                    //Swap
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            temp = array[i + 1];
            array[i + 1] = array[end];
            array[end] = temp;
            return i + 1;
        }

        static int[] BubbleSort(int[] array)
        {
            long numberOfIterations = 0;

            for (var j = 0; j < array.Length - 1; j++)
            {
                for (var i = 0; i < array.Length - 1; i++)
                {
                    numberOfIterations++;
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }

            //Console.WriteLine(numberOfIterations);
            
            return array;
        }

        static int[] RandomArray(int size)
        {
            var array = new int[size];
            var random = new Random();
            for (int i = 0; i < size; i++)
                array[i] = random.Next(size);

            return array;
        }


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

        // 7 % 5 = 2. % calculates the REST of the division.
        // 7 / 2 = 1 + 2 of rest

        static void Main(string[] args)
        {
            var myTime = new Stopwatch();
            var array = RandomArray(50000);
            var bubbleSort = RandomArray(50000);
            var linqSort = RandomArray(50000);
            var listSort = RandomArray(50000);

            //foreach (var element in array) Console.WriteLine(element);
            myTime.Start();

            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("Quick Sort time in ms " + myTime.ElapsedMilliseconds);
            myTime.Restart();

            var secondResult = linqSort.OrderBy(x => x);
            Console.WriteLine("Linq time in ms " + myTime.ElapsedMilliseconds);
            myTime.Restart();

            var result = BubbleSort(bubbleSort);

            Console.WriteLine("Bubble Sort time in ms " + myTime.ElapsedMilliseconds);
            myTime.Restart();

            listSort.ToList().Sort();
            Console.WriteLine("List time in ms " + myTime.ElapsedMilliseconds);
            myTime.Stop();

            //foreach (var element in result) Console.WriteLine(element);

            return;
            EuclidGCD(12315485485, 7454712145);

            //Console.WriteLine("Result: " + EuclidGCDRecursive(12315485485, 7454712145));

            Console.WriteLine("RESULT = " + gcd(12315485485, 7454712145));

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
