using Microsoft.Extensions.Logging;

namespace Voyager.UnitTestLogger.Test
{
	internal class SpyTest
	{

		private Voyager.UnitTestLogger.SpyLog<ScopeTest> logger;
		private MockDataReader dataReader;

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

		protected virtual MockDataReader GetReader(ILogger logger)
		{
			return new MockDataReader(logger);
		}


		protected virtual int GetExpectedValue()
		{
			return 2;
		}
	}

	internal class SpyTestCached : SpyTest
	{
		protected override MockDataReader GetReader(ILogger logger)
		{
			return new MockReaderCached(logger);
		}

		protected override int GetExpectedValue()
		{
			return 1;
		}
	}

	class MockDataReader
	{
		private ILogger logger;

		public MockDataReader(ILogger logger)
		{
			this.logger = logger;
		}

		public virtual int Read()
		{
			logger.LogDebug("Call");
			return 25;
		}
	}

	class MockReaderCached : MockDataReader
	{
		public MockReaderCached(ILogger logger) : base(logger)
		{

		}

		int? stored;
		public override int Read()
		{
			if (stored.HasValue)
				return stored.Value;
			stored = base.Read();
			return stored.Value;
		}
	}
}
