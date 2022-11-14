using System;
using System.Collections.Generic;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach (var word in scrambledWords)
            {
                foreach (var wordListItem in wordList)
                {
                    if(wordListItem.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(word, wordListItem));
                    }
                    else
                    {
                        var scrambledWordArray = word.ToCharArray();
                        var wordListArray = wordListItem.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordListArray);
                        
                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordListArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(word, wordListItem));
                        }
                    }
                }
            }


            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };            
            return matchedWord;
        }
    }
}