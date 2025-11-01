using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    public static int designerPdfViewer(List<int> h, string word)
    {
        int maxH = 0;
        foreach (char c in word)
        {
            int index = c - 'a';
            if (h[index] > maxH)
                maxH = h[index];
        }
        return maxH * word.Length;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> h = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(t => Convert.ToInt32(t)).ToList();
        string word = Console.ReadLine();

        int result = Result.designerPdfViewer(h, word);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
