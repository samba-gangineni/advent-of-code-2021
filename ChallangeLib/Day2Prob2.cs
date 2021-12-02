using System;
using System.IO;

namespace ChallangeLib
{
    public class Day2Prob2 : DayProb
    {
        public void Solution(string filePath)
        {
            string[] instructions = File.ReadAllLines(filePath);
            int x = 0, y = 0, aim = 0;
            for (int instruction = 0; instruction < instructions.Length; instruction++)
            {
                string[] command = instructions[instruction].Split(' ');
                if (command[0] == "forward")
                {
                    x += int.Parse(command[1]);
                    y += aim * int.Parse(command[1]);
                }
                else if (command[0] == "up")
                    aim -= int.Parse(command[1]);
                else if (command[0] == "down")
                    aim += int.Parse(command[1]);
            }
            Console.WriteLine(x * y + ": Final horizontal position by final depth");
        }
    }
}