using DarkDhamon.Common.Extensions;
using NUnit.Framework;

namespace DarkDhamon.Common.Tests.Extensions
{
    public class EnumExtensionsTests
    {
        public enum UseDescriptionTest
        {
            [System.ComponentModel.Description("Uno")]
            One,
            [System.ComponentModel.Description("Dos")]
            Two,
            [System.ComponentModel.Description("Tres")]
            Three,
        }

        [Test]
        [TestCase(UseDescriptionTest.One,true, "Uno")]
        [TestCase(UseDescriptionTest.Two,true, "Dos")]
        [TestCase(UseDescriptionTest.One,false, "One")]
        [TestCase(UseDescriptionTest.Two,false, "Two")]
        public void ToStringUseDescriptionTest(UseDescriptionTest value, bool useDescription, string result)
        {
            Assert.AreEqual(result,value.ToString(useDescription));
        }
    }
}