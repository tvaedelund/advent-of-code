using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MoreLinq;

namespace advent_of_code.Days.Y2019
{
    public static class Day03
    {
        public static void Run(int year, string day)
        {
            // Initialize
            day = $"Day{day}";
            Console.WriteLine($"Y{year}.{day}");

            // Load resources
            var data = File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne("") == 0);
            Debug.Assert(GetResultOne("R75,D30,R83,U83,L12,D49,R71,U7,L72\r\nU62,R66,U55,R34,D71,R55,D58,R83") == 159);
            Debug.Assert(GetResultOne("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51\r\nU98,R91,D20,R16,D67,R40,U7,R15,U6,R7") == 135);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne(data, true);
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
            var circuit = new List<Pos>();

            foreach (var wire in data.Split("\r\n"))
            {
                var pos = new Pos(0, 0);
                foreach (var move in wire.Split(','))
                {
                    pos = Move(move, pos);
                    circuit.Add(pos);
                }
            }

            var intersections = circuit
                .GroupBy(p => p.ToString())
                .Select(pg => new
                {
                    p = pg.Key,
                    c = pg.Count()
                })
                .Where(pg => pg.c > 1)
                .OrderBy(p => p.p);



            return result;
        }

        private static int GetResultTwo(string data)
        {
            var result = 0;

            return result;
        }

        private static Pos Move(string move, Pos pos)
        {
            var dir = move[0];
            var len = int.Parse(move.Substring(1));

            switch (dir)
            {
                case 'U':
                    pos = new Pos(pos.X, pos.Y + 1);
                    break;
                case 'R':
                    pos = new Pos(pos.X + 1, pos.Y);
                    break;
                case 'D':
                    pos = new Pos(pos.X, pos.Y - 1);
                    break;
                default:
                    pos = new Pos(pos.X - 1, pos.Y);
                    break;
            }

            return pos;
        }
    }

    class Pos
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pos(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int Distance => Math.Abs(0 - X) + Math.Abs(0 - Y);

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}