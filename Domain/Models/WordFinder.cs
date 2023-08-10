using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Domain.Models
{
    public class WordFinder : IWordFinder
    {
        private IEnumerable<string> matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            GuardHelper.ThrowIfNull<IEnumerable<string>>(matrix, "Matrix is null", nameof(matrix));
            this.matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            GuardHelper.ThrowIfNull<IEnumerable<string>>(matrix, "wordstream is null", nameof(matrix));
            return CountWords(matrix, wordstream);
        }

        public static IEnumerable<string> CountWords(IEnumerable<string> wordsInput, IEnumerable<string> wordsToTest)
        {
            IDictionary<string, int> occurrencesMap = new Dictionary<string, int>();

            foreach (string wordToFind in wordsToTest)
            {
                foreach (string word in wordsInput)
                {
                    int count = CountOccurrences(word, wordToFind);

                    if (count == 0)
                        continue;

                    UpdateOccurrencesMap(occurrencesMap, wordToFind, count);
                }
            }

            return OrderOccurrencesMap(occurrencesMap);
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

        private static void UpdateOccurrencesMap(IDictionary<string, int> occurrencesMap, string wordToFind, int count)
        {
            if (occurrencesMap.ContainsKey(wordToFind))
            {
                occurrencesMap[wordToFind] += count;
            }
            else
            {
                occurrencesMap.Add(wordToFind, count);
            }
        }

        private static IEnumerable<string> OrderOccurrencesMap(IDictionary<string, int> occurrencesMap)
        {
            return (from entry in occurrencesMap
                    orderby entry.Value descending
                    select entry
                    ).Take(10)
                    .ToDictionary(pair => pair.Key, pair => pair.Value)
                    .Keys.ToList();
        }
    }
}
