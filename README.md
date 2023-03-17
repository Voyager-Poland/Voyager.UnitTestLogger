# Voyager.UnitTestLogger
Simple implementation of ILogger interface. Is fast to use in the unit tests because there is no need to configure DI and builders. It is possible to use it as an output to console or write the result for testing-spy purposes.

## How to use the logger

The class logging into the console has the name: Voyager.UnitTestLogger.ConsoleLogger. This is an example of use in a unit test:

```C#
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
```

## How to use the test-spy functionality

The class Voyager.UnitTestLogger.SpyLog either writes logs to the console and also saves the history of log operation so it could be used for asserting purposes. By a text search condition, it is possible to find out about methods that are processed during the calling of the test.

This is an example how to check the content of the history of logs:

```C#
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

```

There is a method that counts the number of lines in the spy content:

```C#
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
...

```

## ✍️ Authors 

- [@andrzejswistowski](https://github.com/AndrzejSwistowski) - Idea & work. Please let me know if you find out an error or suggestions.

[contributors](https://github.com/Voyager-Poland).

## 🎉 Acknowledgements 

- Przemysław Wróbel - for the icon.
