using RockPaperScissors;
using System.Runtime.InteropServices;

internal class Program
{
    private static Dictionary<string, RPSChoice> ChoiceDictionary = new Dictionary<string, RPSChoice>()
    {
        { "A", RPSChoice.Rock },
        { "B", RPSChoice.Paper },
        { "C", RPSChoice.Scissors },
        { "X", RPSChoice.Rock },
        { "Y", RPSChoice.Paper },
        { "Z", RPSChoice.Scissors }
    };

    private static Dictionary<string, RPSResult> ResultDictionary = new Dictionary<string, RPSResult>()
    {
        { "X", RPSResult.Lose },
        { "Y", RPSResult.Draw },
        { "Z", RPSResult.Win }
    };

    private static void Main(string[] args)
    {
        string path = "C:\\Projects\\Personal\\advent-puzzles\\AdventPuzzles\\RockPaperScissors\\PuzzleInput.txt";
        string[] lines = File.ReadAllLines(path);

        List<RoundResult> roundResults = ExtractRoundResults(lines);

        int totalScore = 0;
        roundResults.ForEach(x => x.DetermineMyChoice());
        totalScore = roundResults.Select(x => x.CalculateScore()).Sum();

        Console.WriteLine(totalScore);
    }

    private static List<RoundResult> ExtractRoundResults(string[] lines)
    {
        List<RoundResult> roundResults = new List<RoundResult>();

        foreach (string line in lines)
        {
            string[] chars = line.Split(' ');
            roundResults.Add(new RoundResult()
            {
                OpponentChoice = ChoiceDictionary.GetValueOrDefault(chars[0]),
                Result = ResultDictionary.GetValueOrDefault(chars[1])
            });
        }

        return roundResults;
    }
}