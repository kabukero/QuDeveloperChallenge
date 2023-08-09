using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class WordFinder : IWordFinder
    {
        private IEnumerable<string> matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            this.matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            return CountWords(matrix, wordstream);
        }

        public static IEnumerable<string> CountWords(IEnumerable<string> wordsInput, IEnumerable<string> wordsToTest)
        {

            foreach (string wordToFind in wordsToTest)
            {
                foreach (string word in wordsInput)
                {
                    int count = CountOccurrences(word, wordToFind);

                    if (count == 0)
                        continue;

                }
            }

            return null;
        }

        private static int CountOccurrences(string word, string wordToFind)
        {
            int count = 0, minIndex = word.IndexOf(wordToFind, 0);

            while (minIndex != -1)
            {
                minIndex = word.IndexOf(wordToFind, minIndex + wordToFind.Length);
                count++;
            }

            return count;
        }
    }
}
