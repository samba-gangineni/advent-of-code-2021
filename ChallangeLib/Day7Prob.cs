using System;
using System.IO;
using System.Linq;

namespace ChallangeLib
{
    public class Day7Prob1 : DayProb
    {
        public void Solution(string filePath)
        {
            int[] instructions = File.ReadAllLines(filePath)
                                    .First()
                                    .Split(',')
                                    .Select(x => Int32.Parse(x))
                                    .ToArray();
            int maxPos = instructions.Max();
            int minPos = instructions.Min();
            int total = Int32.MaxValue;
            foreach (int desiredPos in Enumerable.Range(minPos, maxPos - minPos + 1))
            {
                int currCost = 0;
                foreach (int currPos in instructions)
                    currCost += Math.Abs(desiredPos - currPos);
                if (total > currCost)
                    total = currCost;
            }
            Console.WriteLine($"{total}: minimum cost to move the submarines to the blast position");
        }
    }

    public class Day7Prob2 : DayProb
    {
        public void Solution(string filePath)
        {
            int[] instructions = File.ReadAllLines(filePath)
                                    .First()
                                    .Split(',')
                                    .Select(x => Int32.Parse(x))
                                    .ToArray();
            int maxPos = instructions.Max();
            int minPos = instructions.Min();
            int total = Int32.MaxValue;
            foreach (int desiredPos in Enumerable.Range(minPos, maxPos - minPos + 1))
            {
                int currCost = 0;
                foreach (int currPos in instructions)
                {
                    int diff = Math.Abs(desiredPos - currPos);
                    currCost += (diff * (diff + 1)) / 2;
                }
                if (total > currCost)
                    total = currCost;
            }
            Console.WriteLine($"{total}: minimum cost to move the submarines to the blast position");
        }
    }
}
