using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "C:\\Projects\\Personal\\advent-puzzles\\AdventPuzzles\\CalorieCounting\\PuzzleInput.txt";
        string[] lines = File.ReadAllLines(path);
        List<int> totalAmounts = new List<int>();
        int currentTotalAmount = 0;

        foreach (string line in lines)
        {
            if (Int32.TryParse(line, out int amount))
            {
                currentTotalAmount += amount;
            } else
            {
                totalAmounts.Add(currentTotalAmount);
                currentTotalAmount = 0;
            }
        }

        int top3Sum = (from amount in totalAmounts
                    orderby amount descending
                    select amount).Take(3).Sum();

        Console.WriteLine(top3Sum);
    }
}