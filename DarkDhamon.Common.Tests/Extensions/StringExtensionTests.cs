using DarkDhamon.Common.Extensions;
using NUnit.Framework;

namespace DarkDhamon.Common.Tests.Extensions
{
    public class StringExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase(" ", false)]
        [TestCase("Test", false)]
        public void IsNullOrEmptyTest(string value, bool result)
        {
            Assert.AreEqual(result, value.IsNullOrEmpty());
        }

        [Test]
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase(" ", true)]
        [TestCase("Test", false)]
        public void IsNullOrWhitespaceTest(string value, bool result)
        {
            Assert.AreEqual(result, value.IsNullOrWhitespace());
        }
    }
}