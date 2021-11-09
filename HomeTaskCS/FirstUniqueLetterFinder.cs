using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace HomeTaskCS
{
    [TestFixture]
    public class FirstUniqueLetterFinder
    {
        private class LetterEqualityComparer : IEqualityComparer<char>
        {
            public bool Equals(char x, char y) => Char.ToLower(x).Equals(Char.ToLower(y));

            public int GetHashCode([DisallowNull] char obj) => Char.ToLower(obj).GetHashCode();
        }
        public char first_non_repeating_letter(string str)
        {
            if (str.Equals(string.Empty)) return default;
            // Get a list of all characters from a string
            var characters = new List<char>(str);
            var lower_str = str.ToLower();
            // Get a list of the repetitive characters
            var repetitive_characters = 
                new List<char>(lower_str).GroupBy(c => c).Where(c => c.Count() > 1).Select(c => c.Key);
            // Get a list of unique characters (ignoring the case)
            var unique = characters.Except(repetitive_characters, new LetterEqualityComparer());
            return unique.FirstOrDefault();
        }
        [TestCase("sTreSS", 'T')]
        [TestCase("stress", 't')]
        [TestCase(" Test ", 'e')]
        [TestCase("aABbCccSSs", '\0')]
        [TestCase("", '\0')]
        public void TestFirstNonRepeatingLetter(string str, char expected)
        {
            var result = first_non_repeating_letter(str);
            Assert.AreEqual(expected, result);
        }
    }
}
