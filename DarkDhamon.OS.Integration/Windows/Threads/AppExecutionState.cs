using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace DarkDhamon.OS.Integration.Windows.Threads
{
    public static class AppExecutionState
    {
        public static void SetContinuous(ExecutionState esFlags, ILogger logger = null)
        {
            logger?.LogDebug("AppExecutionState.SetContinuous(esFlags, logger) called");
            Set(esFlags|ExecutionState.Continuous, logger);
        }
        public static void Set(ExecutionState esFlags, ILogger logger = null)
        {
            logger?.LogDebug("AppExecutionState.Set(esFlags, logger) called");
            logger?.LogTrace($"New Execution state: {esFlags}");
            var previousExecutionState = SetThreadExecutionState(esFlags);
            logger?.LogTrace($"Old Execution state: {previousExecutionState}");
        }

        public static void Clear(ILogger logger = null)
        {
            logger?.LogDebug("AppExecutionState.Clear(logger) called");
            Set(ExecutionState.Continuous, logger);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esFlags"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);
    }
}