using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace DarkDhamon.Common.Tests.AbstractTest
{
    public class LogMessage
    {
        public LogLevel Level { get; set; }
        public DateTime Timestamp { get; set; }
        public string Category { get; set; }
        public string FormattedMessage { get; set; }
        public IEnumerable<KeyValuePair<string, object>> State { get; set; }
        public EventId EventId { get; set; }
        public Exception Exception { get; set; }
    }
}