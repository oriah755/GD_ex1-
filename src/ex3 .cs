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
    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        List<int> distinctRanked = ranked.Distinct().ToList();
        List<int> result = new List<int>();
        int index = distinctRanked.Count - 1;

        foreach (int score in player)
        {
            while (index >= 0 && score >= distinctRanked[index])
            {
                index--;
            }
            result.Add(index + 2);
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> player = Console.ReadLine().TrimEnd().Split(' ').Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
