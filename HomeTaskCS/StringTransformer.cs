using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTaskCS
{
    [TestFixture]
    class StringTransformer
    {
        private class InvitedPerson
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public InvitedPerson(string str, char sep = ':')
            {
                var split_str = str.Split(sep);
                FirstName = split_str[0];
                if (split_str.Length > 1)
                    LastName = split_str[1];
                else
                    LastName = string.Empty;
            }
        }
        public string GetTransformedString(string str)
        {
            var result = "";
            var people_array = str.Split(';');
            if (people_array[0] == string.Empty)
                return string.Empty;
            var invited_people = people_array.Select(s => new InvitedPerson(s));
            var sorted_invited_people = invited_people.OrderBy(person => person.LastName.ToUpper()).ThenBy(person => person.FirstName.ToUpper());
            foreach (var person in sorted_invited_people)
                result += $"({person.LastName.ToUpper()}, {person.FirstName.ToUpper()})";
            return result;
        }
        [Test]
        public void Test1()
        {
            var expected =
                "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            var result =
                GetTransformedString("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill");
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test2()
        {
            var expected =
                "";
            var result =
                GetTransformedString("");
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test3()
        {
            var expected =
                "(, FREDCORWILL)(CORWILL, WILFRED)";
            var result =
                GetTransformedString("FredCorwill;Wilfred:Corwill");
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test4()
        {
            var expected =
                "(CORWILL, FRED)(CORWILL, FRED)(TORNBULL, BARNEY)";
            var result =
                GetTransformedString("Fred:Corwill;Fred:Corwill;Barney:TornBull");
            Assert.AreEqual(expected, result);
        }
    }
}
