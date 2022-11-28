using DarkDhamon.Common.Extensions;
using NUnit.Framework;

namespace DarkDhamon.Common.Tests.Extensions;

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

    [Test]
    [TestCase("a, b, c", null, new[]{"a", "b", "c"})]
    [TestCase("a; b; c", "; ", new[]{"a", "b", "c"})]
    public void JoinTest(string result, string separator, string[] listOfStrings)
    {
        if (separator == null)
        {
            Assert.AreEqual(result, listOfStrings.Join());
        }
        else
        {
            Assert.AreEqual(result, listOfStrings.ToString(separator));
            Assert.AreEqual(result, listOfStrings.Join(separator));
        }
    }

    [Test]
    [TestCase("Bob ", "Bob")]
    [TestCase("", null)]
    [TestCase("", "")]
    [TestCase("Bob  ", "Bob ")]
    public void AddSpaceAfterTest(string result, string input)
    {
        Assert.AreEqual(result, input.AddSpaceAfter());
    }

    [Test]
    [TestCase("bob", "bob", "bill")]
    [TestCase("bill", "", "bill")]
    [TestCase("bill", null, "bill")]
    [TestCase("bill", " ", "bill")]
    [TestCase("bill", "\n", "bill")]
    [TestCase("bill", "\r", "bill")]
    [TestCase("bob", "bob", "bill")]
    [TestCase("bill", "", "bill")]
    [TestCase("bill", null, "bill")]
    [TestCase("bill", " ", "bill")]
    [TestCase("bill", "\n", "bill")]
    [TestCase("bill", "\r", "bill")]
    public void IfNullOrWhiteSpaceTest(string result, string testString, string replaceString)
    {
        Assert.AreEqual(result, testString.IfNullOrWhitespace(replaceString));
    }
}