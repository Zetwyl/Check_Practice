using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Logging;

namespace SmartTransactionSystem.Transactions
{
    class CachingTransactionDecorator : ITransaction
    {
        private readonly ITransaction transaction;
        private readonly ILogger logger;
        private decimal? cachedFee = null;

        public decimal Amount => transaction.Amount;
        public string Id => transaction.Id;

        public CachingTransactionDecorator(ITransaction transaction, ILogger logger)
        {
            this.transaction = transaction;
            this.logger = logger;
        }

        public decimal CalculateFee()
        {
            if (cachedFee == null)
            {
                logger.Log($"��������� ������ �������� ��� {Id}", LogLevel.Info);
                cachedFee = transaction.CalculateFee();
            }
            else
            {
                logger.Log($"���������� ��� ��� {Id}", LogLevel.Info);
            }
            return cachedFee.Value;
        }

        public void Process()
        {
            if (cachedFee == null)
            {
                CalculateFee();
            }
            else
            {
                logger.Log($"���������� ���������� �������� � �������� ��� {Id}", LogLevel.Info);
            }
            transaction.Process();
        }

        public void Cancel()
        {
            logger.Log($"����� ���� ��������", LogLevel.Info);
            transaction?.Cancel();
            cachedFee = null;
        }
    }
}