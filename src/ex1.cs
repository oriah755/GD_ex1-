using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static int formingMagicSquare(List<List<int>> s)
    {
        int[,] baseSquare = {
            {8, 1, 6},
            {3, 5, 7},
            {4, 9, 2}
        };

        List<int[,]> allSquares = new List<int[,]>();

        int[,] current = baseSquare;
        for (int i = 0; i < 4; i++)
        {
            allSquares.Add(current);
            current = Rotate(current);
        }

        int[,] flipped = Flip(baseSquare);
        current = flipped;
        for (int i = 0; i < 4; i++)
        {
            allSquares.Add(current);
            current = Rotate(current);
        }

        int minCost = int.MaxValue;

        foreach (int[,] square in allSquares)
        {
            int cost = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cost += Math.Abs(s[i][j] - square[i, j]);
                }
            }

            if (cost < minCost)
            {
                minCost = cost;
            }
        }

        return minCost;
    }

    static int[,] Rotate(int[,] mat)
    {
        int[,] rotated = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotated[j, 2 - i] = mat[i, j];
            }
        }
        return rotated;
    }

    static int[,] Flip(int[,] mat)
    {
        int[,] flipped = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                flipped[i, 2 - j] = mat[i, j];
            }
        }
        return flipped;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        List<List<int>> s = new List<List<int>>();
        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }
        int result = Result.formingMagicSquare(s);
        textWriter.WriteLine(result);
        textWriter.Flush();
        textWriter.Close();
    }
}
