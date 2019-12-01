using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MoreLinq;

namespace advent_of_code.Days.Y2015
{
    public static class Day05
    {
        public static void Run()
        {
            // Initialize
            var day = "Day05";
            var year = "2015";
            Console.WriteLine($"Y{year}.{day}");

            // Load resources
            var data = File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne("ugknbfddgicrmopn") == 1);
            Debug.Assert(GetResultOne("aaa") == 1);
            Debug.Assert(GetResultOne("jchzalrnumimnmhp") == 0);
            Debug.Assert(GetResultOne("haegwjzuvuyypxyu") == 0);
            Debug.Assert(GetResultOne("dvszwmarrgswjxmb") == 0);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne(data);
            Console.WriteLine($"Result 1: {resultOne}");
            Console.WriteLine($"Done in {timerOne.ElapsedMilliseconds} ms");

            // Step 2
            Debug.Assert(GetResultTwo("qjhvhtzxzqqjkmpb") == 1);
            Debug.Assert(GetResultTwo("xxyxx") == 1);
            Debug.Assert(GetResultTwo("aaa") == 0);
            Debug.Assert(GetResultTwo("uurcxstgmygtbstg") == 0);
            Debug.Assert(GetResultTwo("ieodomkazucvgmuy") == 0);

            var timerTwo = Stopwatch.StartNew();
            var resultTwo = GetResultTwo("bgvyzdsv");
            Console.WriteLine($"Result 2: {resultTwo}");
            Console.WriteLine($"Done in {timerTwo.ElapsedMilliseconds} ms");
        }

        private static int GetResultOne(string data)
        {
            var result = 0;

            foreach (var row in data.Split("\r\n"))
            {
                result += (PassRule3(row) && PassRule2(row) && PassRule1(row)) ? 1 : 0;
            }

            return result;
        }

        private static int GetResultTwo(string data)
        {
            var result = 0;

            foreach (var row in data.Split("\r\n"))
            {
                result += (PassRuleTwo1(row) && PassRuleTwo2(row)) ? 1 : 0;
            }

            return result;
        }

        private static bool PassRule1(string data)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            var vowelCount = data
            .Where(c => vowels.Contains(c))
            .Count();

            return vowelCount >= 3;
        }

        private static bool PassRule2(string data)
        {
            var i = 0;
            while (i < data.Length - 1)
            {
                if (data[i] == data[i + 1])
                {
                    return true;
                }

                i++;
            }

            return false;
        }

        private static bool PassRule3(string data)
        {
            var rules = new string[] { "ab", "cd", "pq", "xy" };

            foreach (var rule in rules)
            {
                if (data.Contains(rule))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool PassRuleTwo1(string data)
        {
            var test = data
                //.Select((c, i) => new { c, i })
                .Pairwise((p, e) => new { p, e });

            return false;
        }

        private static bool PassRuleTwo2(string data)
        {
            return false;
        }
    }
}