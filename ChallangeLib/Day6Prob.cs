using System;
using System.IO;
using System.Linq;

namespace ChallangeLib
{
    public class Day6Prob1 : DayProb
    {
        public string filePath;
        public void Solution(string filePath)
        {
            this.filePath = filePath;
            this.CalculateFishPopulation(80);
        }
        public void CalculateFishPopulation(int days)
        {
            int[] currentAges = File.ReadAllLines(this.filePath)
                                    .First()
                                    .Split(',')
                                    .Select(x => Int32.Parse(x))
                                    .ToArray();

            long[] agesCounter = new long[9];
            foreach (int age in currentAges)
                agesCounter[age] += 1;

            // After 0 add a new fish with 8 and current fish continues at 6
            // all other fish decreases by one
            int currDay = 0;
            while (currDay < days)
            {
                currDay += 1;
                long newFish = agesCounter[0];
                foreach (int age in Enumerable.Range(0, agesCounter.Length - 1)) agesCounter[age] = agesCounter[age + 1];
                agesCounter[8] = newFish;
                agesCounter[6] += newFish;
            }
            Console.WriteLine($"For {days} days: number of fish is equal to: {agesCounter.Sum()}");

        }
    }

    public class Day6Prob2 : DayProb
    {
        public void Solution(string filePath)
        {
            Day6Prob1 helper = new Day6Prob1();
            helper.Solution(filePath);
            helper.CalculateFishPopulation(256);
        }
    }
}
