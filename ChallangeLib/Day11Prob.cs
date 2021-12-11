using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ChallangeLib
{
    public class Day11Prob1 : DayProb
    {
        public void Solution(string filePath)
        {
            int[][] octopusEnergy = File.ReadAllLines(filePath)
                                        .Select(x => x.ToCharArray()
                                                    .Select(eachChar => Int32.Parse(eachChar.ToString()))
                                                    .ToArray()
                                        ).ToArray();
            int nrows = octopusEnergy.Length;
            int ncols = octopusEnergy[0].Length;
            int flashes = 0;
            foreach (int step in Enumerable.Range(0, 100))
            {
                Stack<(int row, int col)> flashStack = new Stack<(int row, int col)>();
                HashSet<(int row, int col)> visitedFlash = new HashSet<(int row, int col)>();
                foreach (int row in Enumerable.Range(0, nrows))
                    foreach (int col in Enumerable.Range(0, ncols))
                    {
                        // Add the value
                        octopusEnergy[row][col] += 1;

                        // if value is more than 9 append to the stack
                        if (octopusEnergy[row][col] > 9)
                        {
                            flashStack.Push((row, col));
                            visitedFlash.Add((row, col));
                        }

                    }

                while (flashStack.Count > 0)
                {
                    // pop the row and increase the flash and increment the neighbours
                    (int currRow, int currCol) = flashStack.Pop();
                    flashes += 1;
                    octopusEnergy[currRow][currCol] = 0;

                    // different directions
                    int up = currRow - 1, down = currRow + 1;
                    int left = currCol - 1, right = currCol + 1;
                    bool up_ = up >= 0 && up < nrows, down_ = down >= 0 && down < nrows;
                    bool left_ = left >= 0 && up < ncols, right_ = right >= 0 && right < nrows;
                    // Four directions
                    if (up_ && !visitedFlash.Contains((up, currCol)))
                    {
                        octopusEnergy[up][currCol] += 1;
                        if (octopusEnergy[up][currCol] > 9)
                        {
                            flashStack.Push((up, currCol));
                            visitedFlash.Add((up, currCol));
                        }
                    }
                    if (down_ && !visitedFlash.Contains((down, currCol)))
                    {
                        octopusEnergy[down][currCol] += 1;
                        if (octopusEnergy[down][currCol] > 9)
                        {
                            flashStack.Push((down, currCol));
                            visitedFlash.Add((down, currCol));
                        }
                    }
                    if (left_ && !visitedFlash.Contains((currRow, left)))
                    {
                        octopusEnergy[currRow][left] += 1;
                        if (octopusEnergy[currRow][left] > 9)
                        {
                            flashStack.Push((currRow, left));
                            visitedFlash.Add((currRow, left));
                        }
                    }
                    if (right_ && !visitedFlash.Contains((currRow, right)))
                    {
                        octopusEnergy[currRow][right] += 1;
                        if (octopusEnergy[currRow][right] > 9)
                        {
                            flashStack.Push((currRow, right));
                            visitedFlash.Add((currRow, right));
                        }
                    }
                    // Diagonals
                    if (up_ && left_ && !visitedFlash.Contains((up, left)))
                    {
                        octopusEnergy[up][left] += 1;
                        if (octopusEnergy[up][left] > 9)
                        {
                            flashStack.Push((up, left));
                            visitedFlash.Add((up, left));
                        }
                    }
                    if (down_ && left_ && !visitedFlash.Contains((down, left)))
                    {
                        octopusEnergy[down][left] += 1;
                        if (octopusEnergy[down][left] > 9)
                        {
                            flashStack.Push((down, left));
                            visitedFlash.Add((down, left));
                        }
                    }
                    if (up_ && right_ && !visitedFlash.Contains((up, right)))
                    {
                        octopusEnergy[up][right] += 1;
                        if (octopusEnergy[up][right] > 9)
                        {
                            flashStack.Push((up, right));
                            visitedFlash.Add((up, right));
                        }
                    }
                    if (down_ && right_ && !visitedFlash.Contains((down, right)))
                    {
                        octopusEnergy[down][right] += 1;
                        if (octopusEnergy[down][right] > 9)
                        {
                            flashStack.Push((down, right));
                            visitedFlash.Add((down, right));
                        }
                    }
                }
            }
            Console.WriteLine($"{flashes} in hundred steps");
        }
    }

    public class Day11Prob2 : DayProb
    {
        public void Solution(string filePath)
        {
            int[][] octopusEnergy = File.ReadAllLines(filePath)
                                        .Select(x => x.ToCharArray()
                                                    .Select(eachChar => Int32.Parse(eachChar.ToString()))
                                                    .ToArray()
                                        ).ToArray();
            int nrows = octopusEnergy.Length;
            int ncols = octopusEnergy[0].Length;
            int steps = 1;
            while (steps > 0)
            {
                Stack<(int row, int col)> flashStack = new Stack<(int row, int col)>();
                HashSet<(int row, int col)> visitedFlash = new HashSet<(int row, int col)>();
                foreach (int row in Enumerable.Range(0, nrows))
                    foreach (int col in Enumerable.Range(0, ncols))
                    {
                        // Add the value
                        octopusEnergy[row][col] += 1;

                        // if value is more than 9 append to the stack
                        if (octopusEnergy[row][col] > 9)
                        {
                            flashStack.Push((row, col));
                            visitedFlash.Add((row, col));
                        }

                    }

                while (flashStack.Count > 0)
                {
                    // pop the row and increase the flash and increment the neighbours
                    (int currRow, int currCol) = flashStack.Pop();
                    octopusEnergy[currRow][currCol] = 0;

                    // different directions
                    int up = currRow - 1, down = currRow + 1;
                    int left = currCol - 1, right = currCol + 1;
                    bool up_ = up >= 0 && up < nrows, down_ = down >= 0 && down < nrows;
                    bool left_ = left >= 0 && up < ncols, right_ = right >= 0 && right < nrows;
                    // Four directions
                    if (up_ && !visitedFlash.Contains((up, currCol)))
                    {
                        octopusEnergy[up][currCol] += 1;
                        if (octopusEnergy[up][currCol] > 9)
                        {
                            flashStack.Push((up, currCol));
                            visitedFlash.Add((up, currCol));
                        }
                    }
                    if (down_ && !visitedFlash.Contains((down, currCol)))
                    {
                        octopusEnergy[down][currCol] += 1;
                        if (octopusEnergy[down][currCol] > 9)
                        {
                            flashStack.Push((down, currCol));
                            visitedFlash.Add((down, currCol));
                        }
                    }
                    if (left_ && !visitedFlash.Contains((currRow, left)))
                    {
                        octopusEnergy[currRow][left] += 1;
                        if (octopusEnergy[currRow][left] > 9)
                        {
                            flashStack.Push((currRow, left));
                            visitedFlash.Add((currRow, left));
                        }
                    }
                    if (right_ && !visitedFlash.Contains((currRow, right)))
                    {
                        octopusEnergy[currRow][right] += 1;
                        if (octopusEnergy[currRow][right] > 9)
                        {
                            flashStack.Push((currRow, right));
                            visitedFlash.Add((currRow, right));
                        }
                    }
                    // Diagonals
                    if (up_ && left_ && !visitedFlash.Contains((up, left)))
                    {
                        octopusEnergy[up][left] += 1;
                        if (octopusEnergy[up][left] > 9)
                        {
                            flashStack.Push((up, left));
                            visitedFlash.Add((up, left));
                        }
                    }
                    if (down_ && left_ && !visitedFlash.Contains((down, left)))
                    {
                        octopusEnergy[down][left] += 1;
                        if (octopusEnergy[down][left] > 9)
                        {
                            flashStack.Push((down, left));
                            visitedFlash.Add((down, left));
                        }
                    }
                    if (up_ && right_ && !visitedFlash.Contains((up, right)))
                    {
                        octopusEnergy[up][right] += 1;
                        if (octopusEnergy[up][right] > 9)
                        {
                            flashStack.Push((up, right));
                            visitedFlash.Add((up, right));
                        }
                    }
                    if (down_ && right_ && !visitedFlash.Contains((down, right)))
                    {
                        octopusEnergy[down][right] += 1;
                        if (octopusEnergy[down][right] > 9)
                        {
                            flashStack.Push((down, right));
                            visitedFlash.Add((down, right));
                        }
                    }
                }
                int total = octopusEnergy.Select(x => x.Sum()).Sum();
                if (total == 0) break;
                steps += 1;
            }
            Console.WriteLine($"{steps}: taken to sync");
        }
    }
}
