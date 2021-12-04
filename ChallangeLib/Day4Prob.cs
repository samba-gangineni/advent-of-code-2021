using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ChallangeLib
{
    /*
    You're already almost 1.5km (almost a mile) below the surface of the ocean, already so deep that you can't see any sunlight. What you can see, however, is a giant squid that has attached itself to the outside of your submarine.

    Maybe it wants to play bingo?

    Bingo is played on a set of boards each consisting of a 5x5 grid of numbers. Numbers are chosen at random, and the chosen number is marked on all boards on which it appears. (Numbers may not appear on all boards.) If all numbers in any row or any column of a board are marked, that board wins. (Diagonals don't count.)

    The submarine has a bingo subsystem to help passengers (currently, you and the giant squid) pass the time. It automatically generates a random order in which to draw numbers and a random set of boards (your puzzle input). For example:

    7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

    22 13 17 11  0
    8  2 23  4 24
    21  9 14 16  7
    6 10  3 18  5
    1 12 20 15 19

    3 15  0  2 22
    9 18 13 17  5
    19  8  7 25 23
    20 11 10 24  4
    14 21 16 12  6

    14 21 17 24  4
    10 16 15  9 19
    18  8 23 26 20
    22 11 13  6  5
    2  0 12  3  7
    After the first five numbers are drawn (7, 4, 9, 5, and 11), there are no winners, but the boards are marked as follows (shown here adjacent to each other to save space):

    22 13 17 11  0         3 15  0  2 22        14 21 17 24  4
    8  2 23  4 24         9 18 13 17  5        10 16 15  9 19
    21  9 14 16  7        19  8  7 25 23        18  8 23 26 20
    6 10  3 18  5        20 11 10 24  4        22 11 13  6  5
    1 12 20 15 19        14 21 16 12  6         2  0 12  3  7
    After the next six numbers are drawn (17, 23, 2, 0, 14, and 21), there are still no winners:

    22 13 17 11  0         3 15  0  2 22        14 21 17 24  4
    8  2 23  4 24         9 18 13 17  5        10 16 15  9 19
    21  9 14 16  7        19  8  7 25 23        18  8 23 26 20
    6 10  3 18  5        20 11 10 24  4        22 11 13  6  5
    1 12 20 15 19        14 21 16 12  6         2  0 12  3  7
    Finally, 24 is drawn:

    22 13 17 11  0         3 15  0  2 22        14 21 17 24  4
    8  2 23  4 24         9 18 13 17  5        10 16 15  9 19
    21  9 14 16  7        19  8  7 25 23        18  8 23 26 20
    6 10  3 18  5        20 11 10 24  4        22 11 13  6  5
    1 12 20 15 19        14 21 16 12  6         2  0 12  3  7
    At this point, the third board wins because it has at least one complete row or column of marked numbers (in this case, the entire top row is marked: 14 21 17 24 4).

    The score of the winning board can now be calculated. Start by finding the sum of all unmarked numbers on that board; in this case, the sum is 188. Then, multiply that sum by the number that was just called when the board won, 24, to get the final score, 188 * 24 = 4512.

    To guarantee victory against the giant squid, figure out which board will win first. What will your final score be if you choose that board?
    */
    public struct GameState
    {
        public Dictionary<int, Dictionary<int, string[]>> boards;
        public Dictionary<int, Dictionary<string, int>> counters;

        public GameState(Dictionary<int, Dictionary<int, string[]>> boards, Dictionary<int, Dictionary<string, int>> counters)
        {
            this.boards = boards;
            this.counters = counters;
        }
    }
    public class Day4Prob1 : DayProb
    {
        public void Solution(string filePath)
        {
            this.GetScore(filePath);
        }
        public void GetScore(string filePath, bool winLast = false)
        {
            string[] instructions = File.ReadAllLines(filePath);
            int[] draws = instructions[0].Split(',').Select(eachDraw => Int32.Parse(eachDraw)).ToArray();
            int numOfBoards = (instructions.Length - 1) / 6;
            GameState currGame = this.CreateAllBoardsAndCounters(instructions.Skip(1).ToArray(), numOfBoards);
            int score = this.PlayGame(currGame, draws, winLast);
            Console.WriteLine($"{score}: is the score");
        }
        /**
        For each draw:
            - traverse each board, delete the key from the board, increase the row and column counter, if the counter is 5:
                - then exit from the loop with board number and last draw
                - else continue
        */
        public int PlayGame(GameState game, int[] draws, bool winLast)
        {
            int winningScore = -1;
            foreach (int eachDraw in draws)
            {
                int[] remBoards = game.boards.Keys.ToArray();
                Array.Sort(remBoards);
                foreach (int currBoard in remBoards)
                {
                    int currWinningScore = -1;
                    string[] rowCol;
                    bool keyExists = game.boards[currBoard].TryGetValue(eachDraw, out rowCol);
                    if (!keyExists) continue;
                    game.boards[currBoard].Remove(eachDraw);
                    game.counters[currBoard][rowCol[0]] += 1;
                    game.counters[currBoard][rowCol[1]] += 1;
                    if (game.counters[currBoard][rowCol[0]] == 5 || game.counters[currBoard][rowCol[1]] == 5)
                        currWinningScore = eachDraw * game.boards[currBoard].Sum(x => x.Key);
                    if (winLast && currWinningScore != -1)
                    {
                        game.boards.Remove(currBoard);
                        winningScore = currWinningScore;
                        continue;
                    }
                    if (!winLast && currWinningScore != -1)
                        return winningScore;
                }
            }
            return winningScore;
        }
        public GameState CreateAllBoardsAndCounters(string[] instructions, int numOfBoards)
        {
            Dictionary<int, Dictionary<int, string[]>> allBoards = new Dictionary<int, Dictionary<int, string[]>>();
            Dictionary<int, Dictionary<string, int>> boardCounters = new Dictionary<int, Dictionary<string, int>>();
            int boardCount = 0;
            while (boardCount < numOfBoards)
            {
                string[][] board = instructions.Skip((6 * boardCount) + 1).Take(5).Select(eachRow => Regex.Replace(eachRow.Trim(), @"\s+", " ").Split(' ')).ToArray();
                allBoards.Add(boardCount, this.CreateBoard(board));
                boardCounters.Add(boardCount, this.RowColumnCounter());
                boardCount++;
            }
            return new GameState(allBoards, boardCounters);
        }
        public Dictionary<int, string[]> CreateBoard(string[][] board)
        {
            Dictionary<int, string[]> newBoard = new Dictionary<int, string[]>();

            for (int row = 0; row < 5; row++)
                for (int col = 0; col < 5; col++)
                    newBoard.Add(Int32.Parse(board[row][col]), new[] { $"R_{row}", $"C_{col}" });
            return newBoard;
        }
        public Dictionary<string, int> RowColumnCounter()
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();
            for (int count = 0; count < 5; count++)
            {
                counter.Add($"R_{count}", 0);
                counter.Add($"C_{count}", 0);
            }
            return counter;
        }
    }

    public class Day4Prob2 : DayProb
    {
        public void Solution(string filePath)
        {
            Day4Prob1 helper = new Day4Prob1();
            helper.GetScore(filePath, true);
        }
    }
}
