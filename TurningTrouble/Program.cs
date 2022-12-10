internal class Program
{
    private static int NUMBER_OF_UNIQUE_CHARACTERS = 14;

    private static void Main(string[] args)
    {
        string path = "C:\\Projects\\Personal\\advent-puzzles\\AdventPuzzles\\TurningTrouble\\PuzzleInput.txt";
        string text = File.ReadAllLines(path).First();

        int markerValue = -1;

        for (int i = 0; i < text.Length; i++)
        {
            string subString = text.Substring(i, NUMBER_OF_UNIQUE_CHARACTERS);
            bool areCharactersUnique = subString.Distinct().Count() == NUMBER_OF_UNIQUE_CHARACTERS;

            if (areCharactersUnique)
            {
                markerValue = i + NUMBER_OF_UNIQUE_CHARACTERS;
                break;
            }
        }

        Console.WriteLine(markerValue);
    }
}