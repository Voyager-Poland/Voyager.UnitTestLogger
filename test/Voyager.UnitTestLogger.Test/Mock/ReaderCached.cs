using Microsoft.Extensions.Logging;

namespace Voyager.UnitTestLogger.Test.Mock
{
    internal class ReaderCached : MyDataReader
    {
        public ReaderCached(ILogger logger) : base(logger)
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
