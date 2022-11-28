using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace DarkDhamon.Common.Tests.TestModels;

public class TestLogger<TCategoryName> : TestLogger, ILogger<TCategoryName>
{
    public TestLogger(Func<string, LogLevel, bool> filter = null) : base(typeof(TCategoryName).Name, filter)
    {
    }
}

public class TestLogger : ILogger
{
    public string Category { get; }
    private readonly Func<string, LogLevel, bool> _filter;
    private readonly IList<LogMessage> _logMessages = new List<LogMessage>();

    public TestLogger(string category, Func<string, LogLevel, bool> filter = null)
    {
        _filter = filter;
        Category = category;
    }


    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
        Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;
        var logMessage = new LogMessage()
        {
            Level = logLevel,
            EventId = eventId,
            State = state as IEnumerable<KeyValuePair<string, object>>,
            Exception = exception,
            FormattedMessage = formatter(state, exception),
            Category = Category,
            Timestamp = DateTime.UtcNow,
        };
        _logMessages.Add(logMessage);
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return _filter?.Invoke(Category, logLevel) ?? true;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public IList<LogMessage> GetLogMessages() => _logMessages.ToList();

    public void Clear() => _logMessages.Clear();

    public bool HasErrors()
    {
        return GetLogMessages().Any(log => log.Level is LogLevel.Critical or LogLevel.Error);
    }

    public bool HasWarnings()
    {
        return GetLogMessages().Any(log => log.Level is LogLevel.Warning);
    }

    public bool? HasLogs()
    {
        return GetLogMessages().Any();
    }
}