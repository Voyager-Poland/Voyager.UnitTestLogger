using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Voyager.UnitTestLogger
{

	public class SpyLog<TCattegoryName> : ConsoleLogger<TCattegoryName>
	{
		List<SpyData> spyDataList = new List<SpyData>();
		string spyText = string.Empty;
		protected override string ProcessContent<TState>(TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			var newLine = base.ProcessContent(state, exception, formatter);

			if (!string.IsNullOrEmpty(spyText))
				spyText += Environment.NewLine;
			spyText += newLine;
			return newLine;
		}

		public override void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			AddSpyData(logLevel, eventId, state, exception, formatter);
			base.Log(logLevel, eventId, state, exception, formatter);
		}

		private void AddSpyData<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			this.spyDataList.Add(new SpyData(
					typeof(TCattegoryName).Name,
					logLevel,
					eventId,
					FormatContent(state, exception, formatter),
					exception
			));
		}

		public string GetSpyContent()
		{
			return spyText;
		}

		public int GetLinesCount()
		{
			char[] ch = Environment.NewLine.ToCharArray();
			return this.GetSpyContent().Split(ch, StringSplitOptions.RemoveEmptyEntries).Count();
		}

		public IEnumerable<SpyData> GetSpyData() => spyDataList;
	}
}
