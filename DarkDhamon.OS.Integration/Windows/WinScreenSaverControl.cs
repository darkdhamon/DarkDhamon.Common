using DarkDhamon.OS.Integration.Abstract;
using DarkDhamon.OS.Integration.Windows.Threads;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DarkDhamon.OS.Integration.Windows
{
    public class WinScreenSaverControl: IScreenSaverControl
    {
        private ILogger<WinScreenSaverControl> Logger { get; }

        private bool ControlDisabled { get; } = !Verify.IsWindows();

        public WinScreenSaverControl(ILogger<WinScreenSaverControl> logger)
        {
            Logger = logger;
            if (ControlDisabled)
            {
                Logger.LogWarning("Not running on Windows, Screen Saver Control Disabled");
            }
        }
        public WinScreenSaverControl():this(new NullLogger<WinScreenSaverControl>())
        {
        }
        public void DisableScreenSaver()
        {
            if(ControlDisabled)return;
            Logger.LogDebug("DisableScreenSaver() Called");
            AppExecutionState.SetContinuous(ExecutionState.DisplayRequired|ExecutionState.SystemRequired, Logger);
        }

        public void EnableScreenSaver()
        {
            if (ControlDisabled) return;
            Logger.LogDebug("EnableScreenSaver() Called");
            AppExecutionState.Clear(Logger);
        }
    }
}
