using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "C:\\Projects\\Personal\\advent-puzzles\\AdventPuzzles\\RucksackReorganization\\PuzzleInput.txt";
        string[] lines = File.ReadAllLines(path);
        int totalPriority = 0;

        for (int i = 0; i < lines.Length/3; i++)
        {
            string[] group = lines.Skip(i*3).Take(3).ToArray();
            
            char intersectingChar = group[0].Intersect(group[1]).Intersect(group[2]).First();

            //ascii value to priority
            totalPriority += Char.IsUpper(intersectingChar) ? intersectingChar - 38 : intersectingChar - 96;
        }

        Console.WriteLine(totalPriority);
    }

    private static char FindInterSectingInRucksack(string line)
    {
        var firstHalf = line.Substring(0, line.Length / 2);
        var lastHalf = line.Substring(line.Length / 2, line.Length / 2);

        return firstHalf.Intersect(lastHalf).First();
    }
}