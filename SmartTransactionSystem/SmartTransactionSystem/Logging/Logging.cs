using SmartTransactionSystem.Interfaces;

namespace SmartTransactionSystem.Logging
{
    class Logger : ILogger
    {
        private static readonly Logger instance = new Logger();

        private Logger() { }

        public static Logger Instance => instance;

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}][{level}] {message}");
        }
    }
}