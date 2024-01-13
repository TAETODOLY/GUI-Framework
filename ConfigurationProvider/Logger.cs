using System;

namespace ConfigurationProvider
{
    public static class Logger
    {
        private static readonly string _lock = "";

        public static void WriteLine(string message, bool useSpecflowLogger = false)
        {
            lock (_lock)
            {
                NUnit.Framework.TestContext.Progress.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff") + " - " + message);
            }
        }
    }
}