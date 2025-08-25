using SmartTransactionSystem.Logging;

namespace SmartTransactionSystem.Interfaces
{
    interface ILogger
    {
        void Log(string message, LogLevel level = LogLevel.Info);
    }
}