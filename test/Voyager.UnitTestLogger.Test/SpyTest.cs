using Microsoft.Extensions.Logging;
using Voyager.UnitTestLogger.Test.Mock;

namespace Voyager.UnitTestLogger.Test
{
	internal class SpyTest
	{

		private Voyager.UnitTestLogger.SpyLog<ScopeTest> logger;
		private MyDataReader dataReader;

		[SetUp]
		public void Setup()
		{
			logger = new Voyager.UnitTestLogger.SpyLog<ScopeTest>();
			dataReader = GetReader(logger);
		}

		[Test]
		public void CheckReadCount()
		{
			dataReader.Read();
			dataReader.Read();
			Assert.That(logger.GetLinesCount(), Is.EqualTo(GetExpectedValue()));
		}

		protected virtual MyDataReader GetReader(ILogger logger)
		{
			return new MyDataReader(logger);
		}


		protected virtual int GetExpectedValue()
		{
			return 2;
		}
	}
}
