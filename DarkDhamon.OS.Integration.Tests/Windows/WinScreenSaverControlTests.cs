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
            ScreenSaverControl = new WinScreenSaverControl(Logger);
            ScreenSaverControlNoLogging = new WinScreenSaverControl();
        }
        
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NoLoggingTest()
        {
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
            void Code()
            {
                ScreenSaverControl.DisableScreenSaver();
            }
            Assert.DoesNotThrow(Code);
            Assert.IsTrue(Logger.GetLogMessages().Any(log => log.FormattedMessage.Contains($"New Execution state: {ExecutionState.DisplayRequired | ExecutionState.SystemRequired | ExecutionState.Continuous}")));
        }


    }
}
