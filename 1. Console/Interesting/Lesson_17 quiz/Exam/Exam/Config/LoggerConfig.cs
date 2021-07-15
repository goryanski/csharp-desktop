using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Exam.Config
{
    class LoggerConfig
    {
        public static void Config()
        {
            var config = new LoggingConfiguration();

            var logFile = new FileTarget("logfile") { FileName = "log.txt" };
            var logConsole = new ConsoleTarget("logconsole");

            // на консоль будем выводить только текст сообщения, остальное в консоли не нужно 
            logConsole.Layout = Layout.FromString("${message}");

            config.AddRule(LogLevel.Info, LogLevel.Warn, logConsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);

            LogManager.Configuration = config;
        }
    }
}
