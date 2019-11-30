using System;
using System.Diagnostics;
using System.IO;

namespace advent_of_code.Days.Y2015
{
    public static class Day01
    {
        public static void Run()
        {
            // Initialize
            var day = "Day01";
            var year = "2015";
            Console.WriteLine($"Y{year}.{day}");

            // Load resources
            var data = File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne("(())") == 0);
            Debug.Assert(GetResultOne(("()()")) == 0);
            Debug.Assert(GetResultOne("(((") == 3);
            Debug.Assert(GetResultOne("(()(()(") == 3);
            Debug.Assert(GetResultOne("))(((((") == 3);
            Debug.Assert(GetResultOne("())") == -1);
            Debug.Assert(GetResultOne("))(") == -1);
            Debug.Assert(GetResultOne(")))") == -3);
            Debug.Assert(GetResultOne(")())())") == -3);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne(data);
            Console.WriteLine($"Result 1: {resultOne}");
            Console.WriteLine($"Done in {timerOne.ElapsedMilliseconds} ms");

            // Step 2
            Debug.Assert(GetResultTwo(")") == 1);
            Debug.Assert(GetResultTwo("()())") == 5);

            var timerTwo = Stopwatch.StartNew();
            var resultTwo = GetResultTwo(data);
            Console.WriteLine($"Result 2: {resultTwo}");
            Console.WriteLine($"Done in {timerTwo.ElapsedMilliseconds} ms");
        }

        private static int GetResultOne(string data)
        {
            var start = 0;
            var instructions = data.ToCharArray();

            foreach (var instr in instructions)
            {
                start += (instr == '(') ? 1 : 0;
                start -= (instr == ')') ? 1 : 0;
            }

            return start;
        }

        private static int GetResultTwo(string data)
        {
            var start = 0;
            var pos = 0;
            var instructions = data.ToCharArray();

            for (int i = 0; i < instructions.Length; i++)
            {
                var instr = instructions[i];

                start += (instr == '(') ? 1 : 0;
                start -= (instr == ')') ? 1 : 0;

                if (start == -1)
                {
                    pos = i + 1;
                    break;
                }
            }

            return pos;
        }
    }
}