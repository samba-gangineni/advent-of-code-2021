using System;

namespace ChallangeLib
{
    public class Utils
    {
        public static void Print1DArray(string[] matrix)
        {
            Array.ForEach(matrix, Console.WriteLine);
        }
        public static void Print1DArray(int[] matrix)
        {
            Array.ForEach(matrix, Console.WriteLine);
        }
        public static void Print2DArray(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}