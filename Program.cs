using System;
using advent_of_code.Days;

namespace advent_of_code
{
    class Program
    {
        static void Main(string[] args)
        {
            Run(2019, "03");
        }

        static void Run(int year, string day)
        {
            Type.GetType($"advent_of_code.Days.Y{year}.Day{day}").GetMethod("Run").Invoke(null, new object[] { year, day });
        }
    }
}
