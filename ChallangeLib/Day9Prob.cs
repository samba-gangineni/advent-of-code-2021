using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ChallangeLib
{
    public class Day9Prob1 : DayProb
    {
        public int[][] heights;
        public int nrows;
        public int ncols;

        public void Solution(string filePath)
        {
            this.heights = File.ReadAllLines(filePath)
                                .Select(x => x.ToCharArray()
                                            .Select(eachChar => Int32.Parse(eachChar.ToString()))
                                            .ToArray()
                                ).ToArray();
            this.nrows = heights.Length;
            this.ncols = heights[0].Length;
            int totalRiskLevel = 0;
            foreach (int row in Enumerable.Range(0, this.nrows))
            {
                foreach (int col in Enumerable.Range(0, this.ncols))
                {
                    if (this.IsLowPoint(row, col))
                        totalRiskLevel += this.heights[row][col] + 1;
                }
            }
            Console.WriteLine($"{totalRiskLevel}: is the total risk level");
        }

        public bool IsLowPoint(int row, int col)
        {
            int up_ = row - 1, down_ = row + 1;
            int left_ = col - 1, right_ = col + 1;
            int currHeight = this.heights[row][col];
            // Checking on the up_
            if (up_ >= 0 && up_ < this.nrows && currHeight >= this.heights[up_][col])
                return false;
            // Checking on the down_
            if (down_ >= 0 && down_ < this.nrows && currHeight >= this.heights[down_][col])
                return false;
            // Checking on the up
            if (left_ >= 0 && left_ < this.ncols && currHeight >= this.heights[row][left_])
                return false;
            // Checking on the down
            if (right_ >= 0 && right_ < this.ncols && currHeight >= this.heights[row][right_])
                return false;

            return true;
        }
    }

    public class Day9Prob2 : DayProb
    {
        public int[][] heights;
        public int nrows;
        public int ncols;

        public void Solution(string filePath)
        {
            this.heights = File.ReadAllLines(filePath)
                                .Select(x => x.ToCharArray()
                                            .Select(eachChar => Int32.Parse(eachChar.ToString()))
                                            .ToArray()
                                ).ToArray();
            this.nrows = heights.Length;
            this.ncols = heights[0].Length;
            List<(int, int)> riskPoints = new List<(int row, int col)>();
            foreach (int row in Enumerable.Range(0, this.nrows))
            {
                foreach (int col in Enumerable.Range(0, this.ncols))
                {
                    if (this.IsLowPoint(row, col))
                        riskPoints.Add((row, col));
                }
            }
            Console.WriteLine($"{this.BasinSize(riskPoints)}: is the total product of top three basins");
        }

        public bool IsLowPoint(int row, int col)
        {
            int up_ = row - 1, down_ = row + 1;
            int left_ = col - 1, right_ = col + 1;
            int currHeight = this.heights[row][col];
            // Checking on the up_
            if (up_ >= 0 && up_ < this.nrows && currHeight >= this.heights[up_][col])
                return false;
            // Checking on the down_
            if (down_ >= 0 && down_ < this.nrows && currHeight >= this.heights[down_][col])
                return false;
            // Checking on the up
            if (left_ >= 0 && left_ < this.ncols && currHeight >= this.heights[row][left_])
                return false;
            // Checking on the down
            if (right_ >= 0 && right_ < this.ncols && currHeight >= this.heights[row][right_])
                return false;

            return true;
        }
        public int BasinSize(List<(int row, int col)> riskPoints)
        {
            List<int> basinSizes = new List<int>();
            riskPoints.ForEach(point => basinSizes.Add(this.GetBasinSize(point)));
            return basinSizes.OrderByDescending(x => x).Take(3).Aggregate((total, next) => total * next);
        }

        public int GetBasinSize((int row, int col) point)
        {
            int candidates = 0;
            Queue<(int, int)> neighbours = new Queue<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            neighbours.Enqueue(point);
            while (neighbours.Count > 0)
            {
                // Visited the point
                (int row, int col) currPoint = neighbours.Dequeue();
                if (visited.Contains(currPoint))
                {
                    continue;
                }
                visited.Add(currPoint);
                candidates += 1;

                // Add the neighbours that are higher than the current point 
                // and are not present in the visited map
                int up_ = currPoint.row - 1, down_ = currPoint.row + 1;
                int left_ = currPoint.col - 1, right_ = currPoint.col + 1;
                int currHeight = this.heights[currPoint.row][currPoint.col];
                if (up_ >= 0 && up_ < this.nrows && currHeight < this.heights[up_][currPoint.col])
                    if (!visited.Contains((up_, currPoint.col)) && this.heights[up_][currPoint.col] != 9)
                        neighbours.Enqueue((up_, currPoint.col));
                if (down_ >= 0 && down_ < this.nrows && currHeight < this.heights[down_][currPoint.col])
                    if (!visited.Contains((down_, currPoint.col)) && this.heights[down_][currPoint.col] != 9)
                        neighbours.Enqueue((down_, currPoint.col));
                if (left_ >= 0 && left_ < this.ncols && currHeight < this.heights[currPoint.row][left_])
                    if (!visited.Contains((currPoint.row, left_)) && this.heights[currPoint.row][left_] != 9)
                        neighbours.Enqueue((currPoint.row, left_));
                if (right_ >= 0 && right_ < this.ncols && currHeight < this.heights[currPoint.row][right_])
                    if (!visited.Contains((currPoint.row, right_)) && this.heights[currPoint.row][right_] != 9)
                        neighbours.Enqueue((currPoint.row, right_));
            }
            return candidates;
        }
    }
}
