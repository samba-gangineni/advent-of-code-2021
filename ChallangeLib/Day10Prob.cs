using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ChallangeLib
{
    public class Day10Prob1 : DayProb
    {
        public void Solution(string filePath)
        {
            string[] chunks = File.ReadAllLines(filePath);

            int syntaxError = 0;
            foreach (string chunk in chunks)
            {
                syntaxError += GetSyntaxError(chunk);
            }

            Console.WriteLine($"{syntaxError}: is the syntax error");
        }

        public int GetSyntaxError(string chunk)
        {
            int error = 0;
            Dictionary<char, (char open, int error)> closeToOpenMap = this.GetLegalChunkMapping();         // Creating a dictionary for close to open map
            Stack<char> syntaxChecker = new Stack<char>();                                      // Helps us to check the syntax
            foreach (char brace in chunk)
            {
                if (closeToOpenMap.ContainsKey(brace))
                {
                    char currOpen = syntaxChecker.Count > 0 ? syntaxChecker.Pop() : 'a';
                    if (currOpen != closeToOpenMap[brace].open)
                    {
                        error += closeToOpenMap[brace].error;
                        break;
                    }
                }
                else
                {
                    syntaxChecker.Push(brace);
                }
            }
            return error;
        }

        public Dictionary<char, (char open, int error)> GetLegalChunkMapping()
        {
            Dictionary<char, (char, int)> closeToOpenMap = new Dictionary<char, (char open, int error)>();
            closeToOpenMap.Add(')', ('(', 3));
            closeToOpenMap.Add(']', ('[', 57));
            closeToOpenMap.Add('}', ('{', 1197));
            closeToOpenMap.Add('>', ('<', 25137));
            return closeToOpenMap;
        }
    }

    public class Day10Prob2 : DayProb
    {

        public void Solution(string filePath)
        {
            string[] chunks = File.ReadAllLines(filePath);

            List<long> syntaxError = new List<long>();
            foreach (string chunk in chunks)
            {
                long score = GetSyntaxError(chunk);
                if (score != 0)
                    syntaxError.Add(score);
            }
            syntaxError.ForEach(Console.WriteLine);
            Console.WriteLine($"{syntaxError.OrderBy(x => x).Skip(syntaxError.Count / 2).Take(1).ToList()[0]}: is the syntax error");
        }

        public long GetSyntaxError(string chunk)
        {
            int error = 0;
            Dictionary<char, (char open, int error)> closeToOpenMap = this.GetLegalChunkMapping();         // Creating a dictionary for close to open map
            Dictionary<char, (char open, int score)> openToCloseMap = this.GetAutoCompleteMapping();         // Creating a dictionary for open to close map
            Stack<char> syntaxChecker = new Stack<char>();                                      // Helps us to check the syntax
            foreach (char brace in chunk)
            {
                if (closeToOpenMap.ContainsKey(brace))
                {
                    char currOpen = syntaxChecker.Count > 0 ? syntaxChecker.Pop() : 'a';
                    if (currOpen != closeToOpenMap[brace].open)
                    {
                        error += closeToOpenMap[brace].error;
                        break;
                    }
                }
                else
                {
                    syntaxChecker.Push(brace);
                }
            }
            long score = 0;
            if (syntaxChecker.Count > 0 && error == 0)
            {
                while (syntaxChecker.Count > 0)
                    score = (score * 5) + openToCloseMap[syntaxChecker.Pop()].score;
            }
            return score;
        }

        public Dictionary<char, (char open, int error)> GetLegalChunkMapping()
        {
            Dictionary<char, (char, int)> closeToOpenMap = new Dictionary<char, (char open, int error)>();
            closeToOpenMap.Add(')', ('(', 3));
            closeToOpenMap.Add(']', ('[', 57));
            closeToOpenMap.Add('}', ('{', 1197));
            closeToOpenMap.Add('>', ('<', 25137));
            return closeToOpenMap;
        }
        public Dictionary<char, (char open, int score)> GetAutoCompleteMapping()
        {
            Dictionary<char, (char open, int score)> closeToOpenMap = new Dictionary<char, (char open, int score)>();
            closeToOpenMap.Add('(', (')', 1));
            closeToOpenMap.Add('[', (']', 2));
            closeToOpenMap.Add('{', ('}', 3));
            closeToOpenMap.Add('<', ('>', 4));
            return closeToOpenMap;
        }
    }
}