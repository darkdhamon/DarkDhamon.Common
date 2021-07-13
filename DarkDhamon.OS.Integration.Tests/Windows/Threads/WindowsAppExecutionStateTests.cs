using System.Linq;
using DarkDhamon.Common.Tests.AbstractTest;
using DarkDhamon.OS.Integration.Windows.Threads;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace DarkDhamon.OS.Integration.Tests.Windows.Threads
{
    public class WindowsAppExecutionStateTests : AbstractTestsClass<WindowsAppExecutionStateTests>
    {
        [SetUp]
        public void Setup()
        {
            AppExecutionState.Clear();
        }

        [Test]
        public void ClearTests()
        {
            void Code()
            {
                AppExecutionState.Clear(Logger);
            }
            Assert.DoesNotThrow(Code);
            Assert.IsTrue(Logger.HasLogs());
            var traceLogs = Logger.GetLogMessages().Where(log => log.Level == LogLevel.Trace).ToList();
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"New Execution state: {ExecutionState.Continuous}")));
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"Old Execution state: {ExecutionState.Continuous}")));
        }

        [Test]
        [TestCase(ExecutionState.DisplayRequired)]
        [TestCase(ExecutionState.SystemRequired)]
        [TestCase(ExecutionState.AwaymodeRequired)]
        [TestCase(ExecutionState.DisplayRequired | ExecutionState.SystemRequired)]
        [TestCase(ExecutionState.DisplayRequired | ExecutionState.SystemRequired | ExecutionState.Continuous)]
        public void SetTests(ExecutionState state)
        {
            void Code()
            {
                AppExecutionState.Set(state, Logger);
                AppExecutionState.Clear(Logger);
            }
            Assert.DoesNotThrow(Code);
            Assert.IsTrue(Logger.HasLogs());
            var traceLogs = Logger.GetLogMessages().Where(log => log.Level == LogLevel.Trace).ToList();
            Assert.AreEqual(4, traceLogs.Count);
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"New Execution state: {state}")));
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"Old Execution state: {ExecutionState.Continuous}")));
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"New Execution state: {ExecutionState.Continuous}")));
            if (state.HasFlag(ExecutionState.Continuous))
                Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"Old Execution state: {state}")));
        }

        [Test]
        [TestCase(ExecutionState.DisplayRequired)]
        [TestCase(ExecutionState.SystemRequired)]
        [TestCase(ExecutionState.AwaymodeRequired)]
        [TestCase(ExecutionState.DisplayRequired | ExecutionState.SystemRequired)]
        [TestCase(ExecutionState.DisplayRequired | ExecutionState.SystemRequired | ExecutionState.Continuous)]
        public void SetContinuousTests(ExecutionState state)
        {
            void Code()
            {
                AppExecutionState.SetContinuous(state, Logger);
                AppExecutionState.Clear(Logger);
            }
            Assert.DoesNotThrow(Code);
            Assert.IsTrue(Logger.HasLogs());
            var traceLogs = Logger.GetLogMessages().Where(log => log.Level == LogLevel.Trace).ToList();
            Assert.AreEqual(4, traceLogs.Count);
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"New Execution state: {state}")));
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"Old Execution state: {ExecutionState.Continuous}")));
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"New Execution state: {ExecutionState.Continuous}")));
            Assert.IsTrue(traceLogs.Any(log => log.FormattedMessage.Contains($"Old Execution state: {state}")));
        }
    }
}