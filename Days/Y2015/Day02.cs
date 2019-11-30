using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace advent_of_code.Days.Y2015
{
    public static class Day02
    {
        public static void Run()
        {
            // Initialize
            var day = "Day02";
            var year = "2015";
            Console.WriteLine($"Y{year}.{day}");

            // Load resources
            var data = File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne("2x3x4") == 58);
            Debug.Assert(GetResultOne("1x1x10") == 43);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne(data);
            Console.WriteLine($"Result 1: {resultOne}");
            Console.WriteLine($"Done in {timerOne.ElapsedMilliseconds} ms");

            // Step 2
            Debug.Assert(GetResultTwo("2x3x4") == 34);
            Debug.Assert(GetResultTwo("1x1x10") == 14);

            var timerTwo = Stopwatch.StartNew();
            var resultTwo = GetResultTwo(data);
            Console.WriteLine($"Result 2: {resultTwo}");
            Console.WriteLine($"Done in {timerTwo.ElapsedMilliseconds} ms");
        }

        private static int GetResultOne(string data)
        {
            var totalArea = 0;

            foreach (var box in data.Split("\r\n"))
            {
                var split = box.Split('x').Select(x => int.Parse(x));
                var areas = new int[3];
                areas[0] = split.ElementAt(0) * split.ElementAt(1);
                areas[1] = split.ElementAt(1) * split.ElementAt(2);
                areas[2] = split.ElementAt(2) * split.ElementAt(0);

                totalArea += 2 * areas.Aggregate((r, i) => r + i);
                totalArea += areas.Min();
            }

            return totalArea;
        }

        private static int GetResultTwo(string data)
        {
            var length = 0;

            foreach (var box in data.Split("\r\n"))
            {
                var split = box.Split('x').Select(x => int.Parse(x));
                var smallest = split.OrderBy(x => x).Take(2);

                length += 2 * (smallest.Aggregate((r, i) => r + i));
                length += split.Aggregate((r, i) => r * i);
            }

            return length;
        }
    }
}