using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ChallangeLib
{
    public class Day5Prob1 : DayProb
    {
        public void Solution(string filePath)
        {
            int[][] instructions = File.ReadAllLines(filePath).Select(str => str.Replace(" -> ", ",").Split(",").Select(y => Int32.Parse(y)).ToArray()).ToArray();
            // Get all the values of the dangerous areas
            int count = this.MapDangerousAreas(instructions);
            Console.WriteLine($"{count}: Number of dangerous areas");
        }
        public int MapDangerousAreas(int[][] instructions, bool diagonal = false)
        {
            int min = instructions.Select(x => x.Min()).ToArray().Min();
            int max = instructions.Select(x => x.Max()).ToArray().Max();
            Dictionary<(int x, int y), int> dangerousAreas = this.GetAllCoordinates(max, min);
            foreach (int[] vent in instructions)
            {
                // if x matches
                if (vent[0] == vent[2])
                {
                    int colMax = vent[1] > vent[3] ? vent[1] : vent[3];
                    int colMin = vent[1] > vent[3] ? vent[3] : vent[1];
                    foreach (int colPoint in Enumerable.Range(colMin, (colMax - colMin) + 1))
                        dangerousAreas[(vent[0], colPoint)] += 1;
                }
                // if y matches
                else if (vent[1] == vent[3])
                {
                    int rowMax = vent[0] > vent[2] ? vent[0] : vent[2];
                    int rowMin = vent[0] > vent[2] ? vent[2] : vent[0];
                    foreach (int rowPoint in Enumerable.Range(rowMin, (rowMax - rowMin) + 1))
                        dangerousAreas[(rowPoint, vent[1])] += 1;
                }
                else if (diagonal && Math.Abs((vent[3] - vent[1]) / (vent[2] - vent[0])) == 1)
                {
                    int slope = (vent[3] - vent[1]) / (vent[2] - vent[0]);
                    int intercept = slope == -1 ? vent[0] + vent[1] : vent[1] - vent[0];
                    int rowMax = vent[0] > vent[2] ? vent[0] : vent[2];
                    int rowMin = vent[0] > vent[2] ? vent[2] : vent[0];
                    dangerousAreas[(vent[0], vent[1])] += 1;
                    dangerousAreas[(vent[2], vent[3])] += 1;
                    foreach (int rowPoint in Enumerable.Range(rowMin + 1, (rowMax - rowMin - 1)))
                    {
                        int colPoint = slope == -1 ? intercept - rowPoint : intercept + rowPoint;
                        dangerousAreas[(rowPoint, colPoint)] += 1;
                    }
                }
            }
            return dangerousAreas.Values.ToArray().Where(x => x >= 2).Count();
        }
        public Dictionary<(int x, int y), int> GetAllCoordinates(int max, int min)
        {
            Dictionary<(int x, int y), int> allCoordinates = new Dictionary<(int x, int y), int>();
            foreach (int row in Enumerable.Range(min, (max - min) + 1))
                foreach (int col in Enumerable.Range(min, (max - min) + 1))
                    allCoordinates.Add((row, col), 0);
            return allCoordinates;
        }
    }

    public class Day5Prob2 : DayProb
    {
        public void Solution(string filePath)
        {
            int[][] instructions = File.ReadAllLines(filePath).Select(str => str.Replace(" -> ", ",").Split(",").Select(y => Int32.Parse(y)).ToArray()).ToArray();
            // Get all the values of the dangerous areas
            Day5Prob1 helper = new Day5Prob1();
            int count = helper.MapDangerousAreas(instructions, true);
            Console.WriteLine($"{count}: Number of dangerous areas");
        }
    }
}
