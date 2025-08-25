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
                logger.Log($"Выполняем расчёт комиссии для {Id}", LogLevel.Info);
                cachedFee = transaction.CalculateFee();
            }
            else
            {
                logger.Log($"Используем кеш для {Id}", LogLevel.Info);
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
                logger.Log($"Пропускаем перерасчёт комиссии в процессе для {Id}", LogLevel.Info);
            }
            transaction.Process();
        }

        public void Cancel()
        {
            logger.Log($"Сброс кеша комиссии", LogLevel.Info);
            transaction?.Cancel();
            cachedFee = null;
        }
    }
}