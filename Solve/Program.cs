using System;
using System.IO;
using ChallangeLib;

namespace Solve
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Argument validation
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: dotnet run --project Solve/Solve.csproj [Day] [Prob]\n");
                    Console.WriteLine("If you are using published package:");
                    Console.WriteLine("Usage: ./Solve [Day] [Prob]");
                    Environment.Exit(1);
                }
                int day = int.Parse(args[0]);
                int prob = int.Parse(args[1]);
                if (day < 1 || day > 25 || prob < 1 || prob > 2)
                {
                    throw new ArgumentException("Please check command line arguments");
                }

                string filePath = Path.Combine(Environment.GetEnvironmentVariable("AOC_2021_DATA"), $"Day{day}Prob.txt");
                // Write the logic to download the file directly
                Type problemType = Type.GetType($"ChallangeLib.Day{day}Prob{prob},ChallangeLib");
                DayProb problem = (Activator.CreateInstance(problemType)) as DayProb;
                problem.Solution(filePath);
            }
            catch (System.Exception e)
            {
                if (e.Source != null)
                {
                    Console.WriteLine("System.Exception source: {0}", e.Source);
                }
                throw;
            }
        }
    }
}
