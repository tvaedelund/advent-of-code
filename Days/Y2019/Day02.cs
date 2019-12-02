using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MoreLinq;

namespace advent_of_code.Days.Y2019
{
    public static class Day02
    {
        public static void Run(int year, string day)
        {
            // Initialize
            day = $"Day{day}";
            Console.WriteLine($"Y{year}.{day}");

            // Load resources
            var data = File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne("1,0,0,0,99") == 2);
            Debug.Assert(GetResultOne("2,3,0,3,99") == 6);
            Debug.Assert(GetResultOne("2,4,4,5,99,0") == 9801);
            Debug.Assert(GetResultOne("1,1,1,4,99,5,6,0,99") == 30);
            Debug.Assert(GetResultOne("1,9,10,3,2,3,11,0,99,30,40,50") == 3500);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne(data, true);
            Console.WriteLine($"Result 1: {resultOne}");
            Console.WriteLine($"Done in {timerOne.ElapsedMilliseconds} ms");

            // Step 2
            var timerTwo = Stopwatch.StartNew();
            var resultTwo = GetResultTwo(data);
            Console.WriteLine($"Result 2: {resultTwo}");
            Console.WriteLine($"Done in {timerTwo.ElapsedMilliseconds} ms");
        }

        private static int GetResultOne(string data, bool real = false)
        {
            var prg = data.Split(',').Select(int.Parse).ToArray();
            var result = 0;
            var pos = 0;
            var cmd = prg[0];

            if (real)
            {
                prg[1] = 12;
                prg[2] = 2;
            }

            while (cmd != 99)
            {
                var a = prg[pos + 1];
                var b = prg[pos + 2];
                var c = prg[pos + 3];

                if (cmd == 1)
                {
                    prg[c] = prg[a] + prg[b];
                }
                else if (cmd == 2)
                {
                    prg[c] = prg[a] * prg[b];
                }
                else if (cmd == 99)
                {
                    break;
                }
                else
                {
                    throw new Exception();
                }

                result = prg[c];
                pos += 4;
                cmd = prg[pos];
            }


            return result;
        }

        private static int GetResultTwo(string data)
        {
            var org = data.Split(',').Select(int.Parse).ToArray();
            var result = 0;
            var done = 19690720;

            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    var pos = 0;
                    var prg = org.ToArray();
                    var cmd = prg[0];

                    prg[1] = i;
                    prg[2] = j;

                    while (cmd != 99)
                    {
                        var a = prg[pos + 1];
                        var b = prg[pos + 2];
                        var c = prg[pos + 3];

                        if (cmd == 1)
                        {
                            prg[c] = prg[a] + prg[b];
                        }
                        else if (cmd == 2)
                        {
                            prg[c] = prg[a] * prg[b];
                        }
                        else if (cmd == 99)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception();
                        }

                        result = prg[c];
                        pos += 4;
                        cmd = prg[pos];
                    }

                    if (result == done)
                    {
                        return 100 * i + j;
                    }
                }
            }

            return result;
        }
    }
}