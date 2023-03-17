using Microsoft.Extensions.Logging;

namespace Voyager.UnitTestLogger.Test.Mock
{
	internal class MyDataReader
	{
		private ILogger logger;

		public MyDataReader(ILogger logger)
		{
			this.logger = logger;
		}

		public virtual int Read()
		{
			logger.LogDebug("Call");
			return 25;
		}
	}
}
