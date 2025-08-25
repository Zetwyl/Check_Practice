using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Logging;

namespace SmartTransactionSystem.Transactions
{
    class TransactionCommand : ICommand
    {
        private readonly ITransaction transaction;
        private readonly ILogger logger;
        private bool isExecuted = false;

        public TransactionCommand(ITransaction transaction, ILogger logger)
        {
            this.transaction = transaction;
            this.logger = logger;
        }

        public void Execute()
        {
            if (!isExecuted)
            {
                transaction.Process();
                isExecuted = true;
            }
            else
            {
                logger.Log($"Транзакция {transaction.Id} уже была выполнена.", LogLevel.Warning);
            }
        }

        public void Undo()
        {
            if (isExecuted)
            {
                transaction.Cancel();
                isExecuted = false;
            }
            else
            {
                logger.Log($"Нечего отменять для транзакции {transaction.Id}.", LogLevel.Warning);
            }
        }

        public void Redo()
        {
            logger.Log($"Повтор транзакции {transaction.Id}.", LogLevel.Info);
            Execute();
        }
    }
}
