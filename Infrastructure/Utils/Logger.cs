using System;
using System.IO;

namespace GameAssistant.Utils
{
    public static class Logger
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        public static void Log(string message)
        {
            var logMessage = $"[{DateTime.Now}] {message}";
            //Logger.Log(logMessage);
            File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
        }
    }
}
