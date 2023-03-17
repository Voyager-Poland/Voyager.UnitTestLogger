using Microsoft.Extensions.Logging;
using System;

namespace Voyager.UnitTestLogger
{
	public class ConsoleLogger<TCattegoryName> : MockLogger<TCattegoryName>
	{
		public override void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			Console.WriteLine(ProcessContent(state, exception, formatter));
		}
	}
}
