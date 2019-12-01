using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MoreLinq;

namespace advent_of_code.Days.Y2019
{
    public static class Day01
    {
        public static void Run(int year, string day)
        {
            // Initialize
            day = $"Day{day}";
            Console.WriteLine($"Y{year}.{day}");

            // Load resources
            var data = ""; //File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne("") == 0);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne(data);
            Console.WriteLine($"Result 1: {resultOne}");
            Console.WriteLine($"Done in {timerOne.ElapsedMilliseconds} ms");

            // Step 2
            Debug.Assert(GetResultTwo("") == 0);

            var timerTwo = Stopwatch.StartNew();
            var resultTwo = GetResultTwo(data);
            Console.WriteLine($"Result 2: {resultTwo}");
            Console.WriteLine($"Done in {timerTwo.ElapsedMilliseconds} ms");
        }

        private static int GetResultOne(string data)
        {
            var result = 0;

            return result;
        }

        private static int GetResultTwo(string data)
        {
            var result = 0;

            return result;
        }
    }
}