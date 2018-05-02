using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private const int LettersToChoose = 4;
    private static readonly HashSet<string> UsedCombinations = new HashSet<string>();

    static void Main(string[] args)
    {
        int numberOfLetters = int.Parse(Console.ReadLine());

        var results = FindBlocks(numberOfLetters);

        PrintBlocks(results);
    }

    private static void PrintBlocks(HashSet<string> results)
    {
        Console.WriteLine($"Number of blocks: {results.Count}");

        foreach(var combination in results)
        {
            Console.WriteLine(combination);
        }
    }

    private static void FillLetters(int numberOfLetters, char[] letters)
    {
        for(int i=0; i<numberOfLetters; i++)
        {
            letters[i] = (char)('A' + i);
        }
    }

    public static HashSet<string> FindBlocks(int numberOfLetters)
    {
        var letters = new char[numberOfLetters];
        FillLetters(numberOfLetters, letters);

        bool[] used = new bool[numberOfLetters];
        char[] currentCombination = new char[LettersToChoose];
        HashSet<string> results = new HashSet<string>();

        GenerateVariations(letters, currentCombination, used, results);

        return results;
    }

    private static void GenerateVariations(char[] letters, char[] currentCombination, bool[] used, HashSet<string> results, int index = 0)
    {
        if(index >= currentCombination.Length)
        {
            AddResult(currentCombination, results);
        }
        else
        {
            for(int i=0; i<letters.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    currentCombination[index] = letters[i];
                    GenerateVariations(letters, currentCombination, used, results, index + 1);
                    used[i] = false;
                }
            }
        }

    }

    private static void AddResult(char[] result, HashSet<string> results)
    {
        string currentCombination = new string(result);

        if (!UsedCombinations.Contains(currentCombination))
        {
            results.Add(currentCombination);

            UsedCombinations.Add(currentCombination);
            UsedCombinations.Add(new string(new[] { result[3], result[0], result[2], result[1] }));
            UsedCombinations.Add(new string(new[] { result[2], result[3], result[1], result[0] }));
            UsedCombinations.Add(new string(new[] { result[1], result[2], result[0], result[3] }));
        }
    }
}