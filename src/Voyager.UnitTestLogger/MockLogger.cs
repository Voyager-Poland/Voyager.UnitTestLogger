using Microsoft.Extensions.Logging;
using System;

namespace Voyager.UnitTestLogger
{
	public abstract class MockLogger<TCategoryName> : ScopeProcess, ILogger<TCategoryName>
	{
		public IDisposable BeginScope<TState>(TState state)
		{
			this.LogInformation(state.ToString());
			return new LogScope(this);
		}

		public abstract void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);

		protected virtual string ProcessContent<TState>(TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			return GetSpacess() + formatter.Invoke(state, exception);
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return true;
		}

		int spacesCount = 0;

		string GetSpacess()
		{
			string s = "";
			for (int i = 0; i < spacesCount; i++)
				s += " ";
			return s;
		}


		public void ScopeEnter()
		{
			spacesCount += 2;
		}
		public void ScopeExit()
		{
			spacesCount -= 2;
		}

	}
}
