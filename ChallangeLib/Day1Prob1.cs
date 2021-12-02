using System;
using System.IO;

namespace ChallangeLib
{
    public class Day1Prob1 : DayProb
    {
        public void Solution(string filePath)
        {
            int[] depths = Array.ConvertAll(File.ReadAllLines(filePath), l => int.Parse(l));
            int total = 0;
            for (int depth = 0; depth < depths.Length - 1; depth++)
            {
                if (depths[depth] < depths[depth + 1])
                    total++;
            }
            Console.WriteLine(total + ": measurements are larger than previous measurement");
        }
    }
}
