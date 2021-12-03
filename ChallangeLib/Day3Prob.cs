using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace ChallangeLib
{
    public class Day3Prob1 : DayProb
    {
        public void Solution(string filePath)
        {
            string[] instructions = File.ReadAllLines(filePath);
            int byteLength = instructions[0].Length;
            Dictionary<int, int> counters = this.PlaceCounter(instructions, byteLength);
            StringBuilder gamma = new StringBuilder(byteLength);
            StringBuilder epsilon = new StringBuilder(byteLength);
            for (int i = 0; i < instructions[0].Length; i++)
            {
                if (counters[i] > instructions.Length - counters[i])
                {
                    gamma.Append("1");
                    epsilon.Append("0");
                }
                else
                {
                    gamma.Append("0");
                    epsilon.Append("1");
                }
            }
            int gammaVal = Convert.ToInt32(gamma.ToString(), 2);
            int epsilonVal = Convert.ToInt32(epsilon.ToString(), 2);
            Console.WriteLine($"{gammaVal * epsilonVal}: power consumption of submarine");

        }

        public Dictionary<int, int> PlaceCounter(string[] bytes, int byteLength)
        {
            Dictionary<int, int> digitCounts = new Dictionary<int, int>();
            for (int each_byte = 0; each_byte < bytes.Length; each_byte++)
            {
                for (int i = 0; i < byteLength; i++)
                {
                    if (bytes[each_byte][i] == '1')
                    {
                        int currentCount;
                        digitCounts.TryGetValue(i, out currentCount);
                        digitCounts[i] = currentCount + 1;
                    }
                }
            }
            return digitCounts;
        }
    }

    public class Day3Prob2 : DayProb
    {
        public void Solution(string filePath)
        {
            string[] instructions = File.ReadAllLines(filePath);
            int oxygen = Convert.ToInt32(this.GetRating(instructions, true), 2);
            int co2 = Convert.ToInt32(this.GetRating(instructions, false), 2);
            Console.WriteLine($"ox: {oxygen}, co2: {co2}");
            Console.WriteLine($"{oxygen * co2}: life support rating");
        }

        public string GetRating(string[] bytes, bool maximum)
        {
            int byteLength = bytes[0].Length;
            string[] bytesCopy = (string[])bytes.Clone();
            Day3Prob1 dayProbHelper = new Day3Prob1();
            char majorFilter = maximum ? '1' : '0';
            char minorFilter = maximum ? '0' : '1';
            for (int pos = 0; pos < byteLength; pos++)
            {
                if (bytesCopy.Length > 1)
                {
                    Dictionary<int, int> counter = dayProbHelper.PlaceCounter(bytesCopy, byteLength);
                    char filterChar = counter[pos] >= bytesCopy.Length - counter[pos] ? majorFilter : minorFilter;
                    bytesCopy = Array.FindAll(bytesCopy, x => x[pos] == filterChar);
                }
            }
            return bytesCopy[0];
        }
    }
}
