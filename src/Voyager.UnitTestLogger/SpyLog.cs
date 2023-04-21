using System;
using System.Linq;

namespace Voyager.UnitTestLogger
{
	public class SpyLog<TCattegoryName> : ConsoleLogger<TCattegoryName>
	{
		string spyText = string.Empty;

		protected override string ProcessContent<TState>(TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			var newLine = base.ProcessContent(state, exception, formatter);
			if (!string.IsNullOrEmpty(spyText))
				spyText += Environment.NewLine;
			spyText += newLine;
			return newLine;
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
	}
}
