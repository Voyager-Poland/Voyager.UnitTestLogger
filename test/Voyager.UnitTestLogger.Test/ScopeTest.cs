using Microsoft.Extensions.Logging;

namespace Voyager.UnitTestLogger.Test
{
	public class ScopeTest
	{
		Microsoft.Extensions.Logging.ILogger logger;

		[SetUp]
		public void Setup()
		{
			logger = new Voyager.UnitTestLogger.SpyLog<ScopeTest>();
		}

		[Test]
		public void Test()
		{
			logger.LogInformation("B1");
			using (var scope = logger.BeginScope("S1"))
			{
				logger.LogInformation("L1");
				logger.LogInformation("L2");
				using (var scope2 = logger.BeginScope("S2"))
				{
					logger.LogInformation("m1");
					logger.LogInformation("m2");
				}
				logger.LogInformation("L3");
			}
			logger.LogInformation("B2");
			
			Voyager.UnitTestLogger.SpyLog<ScopeTest> casted = (logger as Voyager.UnitTestLogger.SpyLog<ScopeTest>)!;
			Assert.That(casted.GetSpyContent(), Is.EqualTo(
"B1" + Environment.NewLine +
"S1" + Environment.NewLine +
"  L1" + Environment.NewLine +
"  L2" + Environment.NewLine +
"  S2" + Environment.NewLine +
"    m1" + Environment.NewLine +
"    m2" + Environment.NewLine +
"  L3" + Environment.NewLine +
"B2"
));


		}
	}
}