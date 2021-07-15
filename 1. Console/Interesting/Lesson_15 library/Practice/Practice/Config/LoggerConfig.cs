using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Practice.Config
{
    class LoggerConfig
    {
        public static void Config()
        {
            // -= Конфигурирование логера =-
            var config = new LoggingConfiguration();

            //Настройка источников вывода
            var logFile = new FileTarget("logfile") { FileName = "log.txt" };
            var logConsole = new ConsoleTarget("logconsole");

            // на консоль будем выводить только текст сообщения, остальное в консоли не нужно 
            logConsole.Layout = Layout.FromString("${message}");

            //Настройка правил
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logConsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);

            //Применение правил
            LogManager.Configuration = config;
        }
    }
}
