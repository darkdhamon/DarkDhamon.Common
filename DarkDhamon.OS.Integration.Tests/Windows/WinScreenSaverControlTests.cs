using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkDhamon.Common.Tests.AbstractTest;
using DarkDhamon.OS.Integration.Windows;
using DarkDhamon.OS.Integration.Windows.Threads;
using NUnit.Framework;

namespace DarkDhamon.OS.Integration.Tests.Windows
{
    
    public class WinScreenSaverControlTests:AbstractTestsClass<WinScreenSaverControl>
    {
        public WinScreenSaverControl ScreenSaverControl { get; set; }
        public WinScreenSaverControl ScreenSaverControlNoLogging { get; set; }
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            IsTestSystemWindows = Verify.IsWindows();
            if(!IsTestSystemWindows)return;
            ScreenSaverControl = new WinScreenSaverControl(Logger);
            ScreenSaverControlNoLogging = new WinScreenSaverControl();
        }

        public bool IsTestSystemWindows { get; set; }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NoLoggingTest()
        {
            if (!IsTestSystemWindows)
            {
                Assert.Ignore("Test System is not windows");
            }
            void Code()
            {
                ScreenSaverControlNoLogging.EnableScreenSaver();
                ScreenSaverControlNoLogging.DisableScreenSaver();
            }
            Assert.DoesNotThrow(Code);
        }

        [Test]
        public void EnableScreenSaver()
        {
            if (!IsTestSystemWindows)
            {
                Assert.Ignore("Test System is not windows");
            }
            void Code()
            {
                ScreenSaverControl.EnableScreenSaver();
            }
            Assert.DoesNotThrow(Code);
            Assert.IsTrue(Logger.GetLogMessages().Any(log => log.FormattedMessage.Contains($"New Execution state: {ExecutionState.Continuous}")));
        }

        [Test]
        public void DisableScreenSaver()
        {
            if (!IsTestSystemWindows)
            {
                Assert.Ignore("Test System is not windows");
            }
            void Code()
            {
                ScreenSaverControl.DisableScreenSaver();
            }
            Assert.DoesNotThrow(Code);
            Assert.IsTrue(Logger.GetLogMessages().Any(log => log.FormattedMessage.Contains($"New Execution state: {ExecutionState.DisplayRequired | ExecutionState.SystemRequired | ExecutionState.Continuous}")));
        }


    }
}
