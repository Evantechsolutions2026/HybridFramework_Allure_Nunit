// Logger utility class using log4net for centralized logging across the framework.
// Initializes log4net configuration once using a static constructor and provides
// reusable methods for logging Info and Error messages.
using log4net;
using log4net.Config;
using System.Reflection;

namespace Framework.Utils
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Logger()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
        }

        public static void Info(string message) => log.Info(message);
        public static void Error(string message) => log.Error(message);
    }
}
