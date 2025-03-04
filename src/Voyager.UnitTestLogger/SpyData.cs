using System;
using Microsoft.Extensions.Logging;

namespace Voyager.UnitTestLogger
{
	public class SpyData
	{
		public string CategoryName { get; }
		public LogLevel LogLevel { get; }
		public EventId EventId { get; }
		public string Content { get; }
		public Exception Exception { get; }

		public SpyData(string categoryName, LogLevel logLevel, EventId eventId, string content, Exception exception)
		{
			CategoryName = categoryName;
			LogLevel = logLevel;
			EventId = eventId;
			Content = content;
			Exception = exception;
		}
	}
}
