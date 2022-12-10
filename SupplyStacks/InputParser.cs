using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SupplyStacks
{
    public static class InputParser
    {
        public static List<Stack<char>> DetermineStacks(string[] lines)
        {
            List<Stack<char>> stacks = new();

            int indexOfSeparation = Array.FindIndex(lines, FindIndexOfSeparation);
            int nrOfStacks = lines[indexOfSeparation - 1].Replace(" ", "").Length;

            for (int stackIndex = 0; stackIndex < nrOfStacks; stackIndex++)
            {
                Stack<char> stack = new();

                for (int j = indexOfSeparation - 2; j >= 0; j--)
                {
                    int charIndex = 1 + (stackIndex * 4);
                    char charToPush = lines[j].Substring(charIndex, 1).First();

                    if (!charToPush.Equals(' '))
                    {
                        stack.Push(charToPush);
                    }
                    else
                    {
                        break;
                    }
                }

                stacks.Add(stack);
            }

            return stacks;
        }

        internal static List<Instruction> DetermineInstructions(string[] lines)
        {
            List<Instruction> instructions = new();

            int indexOfSeparation = Array.FindIndex(lines, FindIndexOfSeparation);

            for (int i = indexOfSeparation + 1; i < lines.Length; i++)
            {
                int[] values = Array.ConvertAll(lines[i]
                    .Replace("move ", "")
                    .Replace("from ", "")
                    .Replace("to ", "")
                    .Split(' '), s => int.Parse(s));

                instructions.Add(new Instruction()
                {
                    Amount = values[0],
                    From = values[1],
                    To = values[2]
                });
            }

            return instructions;
        }

        private static bool FindIndexOfSeparation(string line)
        {
            return string.IsNullOrWhiteSpace(line);
        }
    }
}
