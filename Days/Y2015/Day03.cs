using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MoreLinq;

namespace advent_of_code.Days.Y2015
{
    public static class Day03
    {
        public static void Run()
        {
            // Initialize
            var day = "Day03";
            var year = "2015";
            Console.WriteLine($"Y{year}.{day}");

            // Load resources
            var data = File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne(">") == 2);
            Debug.Assert(GetResultOne("^>v<") == 4);
            Debug.Assert(GetResultOne("^v^v^v^v^v") == 2);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne(data);
            Console.WriteLine($"Result 1: {resultOne}");
            Console.WriteLine($"Done in {timerOne.ElapsedMilliseconds} ms");

            // Step 2
            Debug.Assert(GetResultTwo("^v") == 3);
            Debug.Assert(GetResultTwo("^>v<") == 3);
            Debug.Assert(GetResultTwo("^v^v^v^v^v") == 11);

            var timerTwo = Stopwatch.StartNew();
            var resultTwo = GetResultTwo(data);
            Console.WriteLine($"Result 2: {resultTwo}");
            Console.WriteLine($"Done in {timerTwo.ElapsedMilliseconds} ms");
        }

        private static int GetResultOne(string data)
        {
            var result = data
                .Scan(new { x = 0, y = 0 }, (current, c) =>
                    c == '^' ? new { x = current.x, y = current.y + 1 } :
                    c == '>' ? new { x = current.x + 1, y = current.y } :
                    c == 'v' ? new { x = current.x, y = current.y - 1 } :
                               new { x = current.x - 1, y = current.y })
                .Select(point => $"{point.x},{point.y}")
                .GroupBy(point => point)
                .Count();

            return result;
        }

        private static int GetResultTwo(string data)
        {
            var result = data
                .Batch(2)
                .Scan(new { santa = (x: 0, y: 0), robot = (x: 0, y: 0) }, (current, c) =>
                    new { santa = Move(current.santa, c.First()), robot = Move(current.robot, c.Last()) }
                )
                .SelectMany(points => new[] { points.santa, points.robot })
                .Select(point => $"{point.x},{point.y}")
                .GroupBy(point => point)
                .Count();

            return result;
        }

        private static (int x, int y) Move((int x, int y) current, char dir)
        {
            var newPos = (dir == '^') ? (x: current.x, y: current.y + 1) :
                         (dir == '>') ? (x: current.x + 1, y: current.y) :
                         (dir == 'v') ? (x: current.x, y: current.y - 1) :
                                        (x: current.x - 1, y: current.y);

            return newPos;
        }
    }
}