using System;

namespace DarkDhamon.OS.Integration.Windows.Threads
{
    [Flags]
    public enum ExecutionState : uint
    {
        /// <summary>
        /// Process only runs when computer is idle, This prevents true sleep mode.
        /// </summary>
        AwaymodeRequired = 0x00000040,
        /// <summary>
        /// Change Reset to Disable when combined with other modes, will override previous modes
        /// </summary>
        Continuous = 0x80000000,
        /// <summary>
        /// Reset ScreenSaver and Monitor Power off Timer on Idle
        /// </summary>
        DisplayRequired = 0x00000002,
        /// <summary>
        /// Reset Sleep on Idle Timer
        /// </summary>
        SystemRequired = 0x00000001
    }
}