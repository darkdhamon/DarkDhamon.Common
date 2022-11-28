using System.Text;
using System.Threading.Tasks;
using DarkDhamon.Common.Tests.TestModels;
using NUnit.Framework;

namespace DarkDhamon.Common.Tests.AbstractTest
{
    public abstract class AbstractTestsClass<TestedClass>
    {
        public TestLogger<TestedClass> Logger { get; set; }

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            Logger = new TestLogger<TestedClass>();
        }
        [SetUp]
        public void BaseSetup()
        {
            Logger.Clear();
        }
    }
}

