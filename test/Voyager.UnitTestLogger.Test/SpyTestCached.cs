using Microsoft.Extensions.Logging;
using Voyager.UnitTestLogger.Test.Mock;

namespace Voyager.UnitTestLogger.Test
{
    internal class SpyTestCached : SpyTest
	{
		protected override MyDataReader GetReader(ILogger logger)
		{
			return new ReaderCached(logger);
		}

		protected override int GetExpectedValue()
		{
			return 1;
		}
	}
}
