

using Voyager.UnitTestLogger.Test.Mock;

namespace Voyager.UnitTestLogger.Test
{
	internal class SimpleExample
	{
		private MyDataReader dataReader;

		[SetUp]
		public void Setup()
		{
			dataReader = new MyDataReader(new Voyager.UnitTestLogger.ConsoleLogger<MyDataReader>());
		}

		[Test]
		public void Example()
		{
			dataReader.Read();
			Assert.Pass();
		}
	}
}
