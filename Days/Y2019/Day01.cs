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
            var data = File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne("12") == 2);
            Debug.Assert(GetResultOne("14") == 2);
            Debug.Assert(GetResultOne("1969") == 654);
            Debug.Assert(GetResultOne("100756") == 33583);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne(data);
            Console.WriteLine($"Result 1: {resultOne}");
            Console.WriteLine($"Done in {timerOne.ElapsedMilliseconds} ms");

            // Step 2
            Debug.Assert(GetResultTwo("12") == 2);
            Debug.Assert(GetResultTwo("14") == 2);
            Debug.Assert(GetResultTwo("1969") == 966);
            Debug.Assert(GetResultTwo("100756") == 50346);

            var timerTwo = Stopwatch.StartNew();
            var resultTwo = GetResultTwo(data);
            Console.WriteLine($"Result 2: {resultTwo}");
            Console.WriteLine($"Done in {timerTwo.ElapsedMilliseconds} ms");
        }

        private static double GetResultOne(string data)
        {
            var result = 0d;

            foreach (var row in data.Split("\r\n").Select(int.Parse))
            {
                result += Math.Floor(row / 3d) - 2;
            }

            return result;
        }

        private static double GetResultTwo(string data)
        {
            var result = 0d;

            foreach (var row in data.Split("\r\n").Select(int.Parse))
            {
                result += GetRemainingFuel(row);
            }

            return result;
        }

        private static double GetRemainingFuel(double fuel)
        {
            var result = 0d;
            var current = fuel;

            while (true)
            {
                current = Math.Floor(current / 3d) - 2;
                if (current <= 0)
                {
                    break;
                }

                result += current;
            }

            return result;
        }
    }
}