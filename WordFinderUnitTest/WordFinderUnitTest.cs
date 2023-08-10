using Domain.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace WordFinderUnitTest
{
    public class WordFinderUnitTest
    {
        [Fact]
        public void When_Matrix_IsNull_ThrowsArgumentException()
        {
            IEnumerable<string> actual = null;
            Assert.Throws<ArgumentException>(() => new WordFinder(actual));
        }

        [Fact]
        public void When_WordStreams_IsNull_ThrowsArgumentException()
        {
            IEnumerable<string> actual = new List<string>() { "abcde", "fgwiofgwio", "fgwio", "chill", "pqnsd", "uvdxy" };
            IEnumerable<string> values = null;
            IWordFinder wordFinder = new WordFinder(actual);
            Assert.Throws<ArgumentException>(() => new WordFinder(values));
        }

        [Fact]
        public void Should_Return_Five_Words_List_When_Pass_Five_Words_Included()
        {
            IEnumerable<string> matrix = new List<string>() { "abcde", "fgwiofgwio", "fgwio", "chill", "pqnsd", "uvdxy" };
            IEnumerable<string> wordStream = new List<string>() { "abcde", "abcde", "fgwio", "chill", "chill", "pqnsd", "uvdxy", "pepe", "argento" };
            IEnumerable<string> expected = new List<string>() { "fgwio", "abcde", "chill", "pqnsd", "uvdxy" };
            IWordFinder wordFinder = new WordFinder(matrix);
            IEnumerable<string> actual = wordFinder.Find(wordStream);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Return_Empty_Enumarable_When_Pass_Words_That_Are_Not_Included()
        {
            IEnumerable<string> matrix = new List<string>() { "abcde", "fgwiofgwio", "fgwio", "chill", "pqnsd", "uvdxy" };
            IEnumerable<string> wordStream = new List<string>() { "Ben", "Stiller" };
            IWordFinder wordFinder = new WordFinder(matrix);
            IEnumerable<string> actual = wordFinder.Find(wordStream);
            Assert.Empty(actual);
        }
    }
}