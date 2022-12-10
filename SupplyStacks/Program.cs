using SupplyStacks;

internal class Program
{
    private static List<Stack<char>> stacks = new();

    private static void Main(string[] args)
    {
        string path = "C:\\Projects\\Personal\\advent-puzzles\\AdventPuzzles\\SupplyStacks\\PuzzleInput.txt";
        string[] lines = File.ReadAllLines(path);

        List<Stack<char>> stacks = InputParser.DetermineStacks(lines);
        List<Instruction> instructions = InputParser.DetermineInstructions(lines);

        foreach (Instruction instruction in instructions)
        {
            List<char> charsToMove = new();

            for (int i = 0; i < instruction.Amount; i++)
            {
                charsToMove.Add(stacks[instruction.From - 1].Pop());
            }

            charsToMove.Reverse();
            charsToMove.ForEach(charToMove => stacks[instruction.To - 1].Push(charToMove));
        }

        string topChars = new string(stacks.Select(stack => stack.Pop()).ToArray());
        Console.WriteLine(topChars);
    }
}