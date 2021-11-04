using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeTaskCS
{
    [TestFixture]
    public class ListFilter
    {
        public List<int> GetIntegersFromList(List<object> initial_list) =>
            initial_list.Where(ob => ob.GetType().Equals(typeof(int))).Select(ob => (int)ob).ToList<int>();
        [Test]
        public void Test1()
        {
            var list = new List<object>() { 1, 2, 'a', 'b' };
            var expected = new List<int>() { 1, 2 };
            var result = GetIntegersFromList(list);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test2()
        {
            var list = new List<object>() { 1, 2, 'a', 'b', 0, 15 };
            var expected = new List<int>() { 1, 2, 0, 15 };
            var result = GetIntegersFromList(list);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test3()
        {
            var list = new List<object>() { 1, 2, 'a', 'b', "aasf", '1', "123", 231 };
            var expected = new List<int>() { 1, 2, 231 };
            var result = GetIntegersFromList(list);
            Assert.AreEqual(expected, result);
        }
    }
}
