using System;

namespace Voyager.UnitTestLogger
{
	class LogScope : IDisposable
	{
		private readonly ScopeProcess owner;

		public LogScope(ScopeProcess owner)
		{
			this.owner = owner;
			this.owner.ScopeEnter();
		}

		public void Dispose()
		{
			this.owner.ScopeExit();
		}
	}
}
