using Task3;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Task3
    {
        [Test]
        public void Predicate_NestedArray_Test()
        {
            var data = new List<IEnumerable<string>>()
            {
                new [] {"", "", "", "", "", ""},
                new [] {"", ""}
            };
            var result = Lists.OnlyBigCollections(data);
            Assert.That(result, Has.Exactly(1).Items);
        }

        [Test]
        public void Predicate_NestedList_Test()
        {
            var data = new List<IEnumerable<string>>()
            {
                new List<string> {"", "", "", "", "", ""},
                new List<string> {"", ""}
            };
            var result = Lists.OnlyBigCollections(data);
            Assert.That(result, Has.Exactly(1).Items);
        }
    }
}