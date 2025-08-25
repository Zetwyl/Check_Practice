using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Logging;

namespace SmartTransactionSystem.Transactions
{
    class LoggingTransactionDecorator : ITransaction
    {
        private readonly ITransaction innerTransaction;
        private readonly ILogger logger;

        public decimal Amount => innerTransaction.Amount;
        public string Id => innerTransaction.Id;

        public LoggingTransactionDecorator(ITransaction transaction, ILogger logger)
        {
            innerTransaction = transaction;
            this.logger = logger;
        }

        public decimal CalculateFee() => innerTransaction.CalculateFee();

        public void Process()
        {
            logger.Log($"������ ��������� ���������� {Id}", LogLevel.Info);
            innerTransaction.Process();
            logger.Log($"���������� ��������� ���������� {Id}", LogLevel.Info);
        }

        public void Cancel()
        {
            logger.Log($"������ ���������� {Id}", LogLevel.Info);
            innerTransaction.Cancel();
            logger.Log($"���������� {Id} ��������", LogLevel.Info);
        }
    }
}