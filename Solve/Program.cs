using System;
using System.IO;
using ChallangeLib;

namespace Solve
{
    class Program
    {
        static void Main(string[] args)
        {
            // try
            // {
            //     // Argument validation
            //     if (args.Length != 2)
            //     {
            //         Console.WriteLine("Usage: dotnet run --project Solve/Solve.csproj [Day] [Prob]");
            //         Environment.Exit(1);
            //     }
            //     int day = int.Parse(args[0]);
            //     int prob = int.Parse(args[1]);
            //     if (day < 1 || day > 25 || prob < 1 || prob > 2)
            //     {
            //         throw new ArgumentException("Please check command line arguments");
            //     }

            //     string filePath = Path.Combine(Environment.CurrentDirectory, "data", $"Day{day}Problem.txt");
            //     // Write the logic to download the file directly
            //     Assembly asm = Assembly.Load("ChallangeLib");
            //     string test = $"ChallangeLib.Day{day}Prob{prob},ChallangeLib";
            //     Type problemType = Type.GetType(test);
            //     DayProb problem = (Activator.CreateInstance(problemType)) as DayProb;
            //     problem.Solution(filePath);
            // }
            // catch (System.Exception e)
            // {
            //     if (e.Source != null)
            //     {
            //         Console.WriteLine("System.Exception source: {0}", e.Source);
            //     }
            //     throw;
            // }
            string filePath = Path.Combine(Environment.CurrentDirectory, "data", "Day2Prob.txt");
            Day2Prob1 problem = new Day2Prob1();
            Day2Prob2 problem2 = new Day2Prob2();
            problem.Solution(filePath);
            problem2.Solution(filePath);
        }
    }
}
