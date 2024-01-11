using System;

namespace ConfigurationProvider
{
    public static class Logger
    {
        private static readonly string _lock = "";
        //public static ISpecFlowOutputHelper specflowLogger;
        public static TechTalk.SpecFlow.Infrastructure.SpecFlowOutputHelper specflowLogger;

        public static void WriteLine(string message, bool useSpecflowLogger = false)
        {
            lock (_lock)
            {
                if (useSpecflowLogger && specflowLogger != null)
                {
                    specflowLogger.WriteLine(message);
                }
                NUnit.Framework.TestContext.Progress.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff") + " - " + message);
            }
        }
    }
}