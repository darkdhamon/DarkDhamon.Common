using System;
using System.Linq;
using DarkDhamon.Common.Tests.AbstractTest;
using DarkDhamon.OS.Integration.Windows;
using DarkDhamon.OS.Integration.Windows.Threads;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace DarkDhamon.OS.Integration.Tests.Windows.Threads
{
    public class WindowsAppExecutionStateTests : AbstractTestsClass<WindowsAppExecutionStateTests>
    {
        public bool IsTestSystemWindows { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            IsTestSystemWindows = Verify.IsWindows();
        }
        [SetUp]
        public void Setup()
        {
            if (IsTestSystemWindows)
            {
                AppExecutionState.Clear();
            }
        }

        [Test]
        public void ClearTests()
        {
            if (!IsTestSystemWindows)
            {
                Assert.Ignore("Test System is not windows");
            }
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
            if (!IsTestSystemWindows)
            {
                Assert.Ignore("Test System is not windows");
            }
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
            if (!IsTestSystemWindows)
            {
                Assert.Ignore("Test System is not windows");
            }
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