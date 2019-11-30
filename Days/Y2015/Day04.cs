using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MoreLinq;

namespace advent_of_code.Days.Y2015
{
    public static class Day04
    {
        public static void Run()
        {
            // Initialize
            var day = "Day04";
            var year = "2015";
            Console.WriteLine($"Y{year}.{day}");

            // Load resources
            //var data = File.ReadAllText(@$".\Inputs\Y{year}\{day.ToLower()}.txt");

            // Step 1
            Debug.Assert(GetResultOne("abcdef") == 609043);
            Debug.Assert(GetResultOne("pqrstuv") == 1048970);

            var timerOne = Stopwatch.StartNew();
            var resultOne = GetResultOne("bgvyzdsv");
            Console.WriteLine($"Result 1: {resultOne}");
            Console.WriteLine($"Done in {timerOne.ElapsedMilliseconds} ms");

            // Step 2
            // Debug.Assert(GetResultTwo("^v") == 3);
            // Debug.Assert(GetResultTwo("^>v<") == 3);
            // Debug.Assert(GetResultTwo("^v^v^v^v^v") == 11);

            var timerTwo = Stopwatch.StartNew();
            var resultTwo = GetResultTwo("bgvyzdsv");
            Console.WriteLine($"Result 2: {resultTwo}");
            Console.WriteLine($"Done in {timerTwo.ElapsedMilliseconds} ms");
        }

        private static int GetResultOne(string data)
        {
            var result = 0;
            using (MD5 md5Hash = MD5.Create())
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    var key = $"{data}{i}";
                    var hash = GetMd5Hash(md5Hash, key);
                    if (hash.StartsWith("00000"))
                    {
                        result = i;
                        break;
                    }
                }
            }

            return result;
        }

        private static int GetResultTwo(string data)
        {
            var result = 0;
            using (MD5 md5Hash = MD5.Create())
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    var key = $"{data}{i}";
                    var hash = GetMd5Hash(md5Hash, key);
                    if (hash.StartsWith("000000"))
                    {
                        result = i;
                        break;
                    }
                }
            }

            return result;
        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?redirectedfrom=MSDN&view=netframework-4.8
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}