﻿using System;
using System.IO;
using ChallangeLib;

namespace Solve
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "data", "Day1Prob1.txt");
            Day1Prob1 prob1 = new Day1Prob1();
            prob1.Solution(filePath);
        }
    }
}