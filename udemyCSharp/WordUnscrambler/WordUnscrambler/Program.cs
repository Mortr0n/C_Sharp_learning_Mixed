using System;
using System.Collections.Generic;
using System.Linq;

namespace WordUnscrambler
{
    internal class Program
    {
        private const string wordListFileName = "wordlist.txt";
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;

            do
            {
                Console.WriteLine("Please enter option - F for file and M for Manual.");
                var option = Console.ReadLine() ?? String.Empty;

                switch(option.ToUpper())
                {
                    case "F":
                        Console.Write("Enter Scrambled Words file name: ");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.Write("Enter scrambled words Manually: ");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine("Whatchu talkin' 'bout?!?");
                        break;
                }

                var continueDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N ");
                    continueDecision = (Console.ReadLine() ?? string.Empty);
                } while (
                    !continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                    !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var fileName = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine($"Match found for scrambled word: {matchedWord.ScrambledWord} - {matchedWord.Word}");
                }

            }
            else
            {
                Console.WriteLine("No matches found.")
            }
        }
    }
}
