using CampCleanup;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "C:\\Projects\\Personal\\advent-puzzles\\AdventPuzzles\\CampCleanup\\PuzzleInput.txt";
        string[] lines = File.ReadAllLines(path);

        int numberOfFullyContained = 0;
        int numberOfIntersecting = 0;

        foreach (string line in lines)
        {
            var assignments = line.Split(',');
            int[] firstRange = Array.ConvertAll(assignments[0].Split('-'), s => int.Parse(s));
            int[] secondRange = Array.ConvertAll(assignments[1].Split('-'), s => int.Parse(s));

            Pair pair = new Pair()
            {
                FirstElfAssignedSections = Enumerable.Range(firstRange[0], firstRange[1] - firstRange[0] + 1).ToList(),
                SecondElfAssignedSections = Enumerable.Range(secondRange[0], secondRange[1] - secondRange[0] + 1).ToList()
            };

            bool FirstIsSubsetOfSecond = !pair.FirstElfAssignedSections.Except(pair.SecondElfAssignedSections).Any();
            bool SecondIsSubsetOfSecond = !pair.SecondElfAssignedSections.Except(pair.FirstElfAssignedSections).Any();

            numberOfFullyContained += FirstIsSubsetOfSecond || SecondIsSubsetOfSecond ? 1 : 0;
            numberOfIntersecting += pair.FirstElfAssignedSections.Intersect(pair.SecondElfAssignedSections).Any() ? 1 : 0;
        }

        Console.WriteLine(numberOfIntersecting);
    }
}