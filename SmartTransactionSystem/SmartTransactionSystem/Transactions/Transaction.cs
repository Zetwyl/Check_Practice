using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Validators;
using SmartTransactionSystem.Logging;

namespace SmartTransactionSystem.Transactions
{
    abstract class Transaction : ITransaction
    {
        public decimal Amount { get; protected set; }
        public string Id { get; protected set; }

        protected virtual decimal MaxAmount => 100_000m;
        public decimal MaxAllowedAmount => MaxAmount;

        protected IFeeStrategy feeStrategy;
        private TransactionValidator validator;
        protected ILogger logger;

        private readonly List<ITransactionObserver> observers = new List<ITransactionObserver>();

        public decimal Fee => CalculateFee();
        public decimal NetAmount => Amount - Fee;

        public void Subscribe(ITransactionObserver observer) => observers.Add(observer);
        public void Unsubscribe(ITransactionObserver observer) => observers.Remove(observer);

        protected virtual void Notify()
        {
            foreach (var observer in observers)
            {
                observer.OnTransactionProcessed(Id);
            }
            logger.Log($"Транзакция {Id}: Уведомления отправлены подписчикам.", LogLevel.Info);
        }

        public Transaction(decimal amount, string id, TransactionValidator validator, IFeeStrategy feeStrategy, ILogger logger)
        {
            Amount = amount;
            Id = id;
            this.validator = validator;
            this.feeStrategy = feeStrategy;
            this.logger = logger;
        }

        public decimal CalculateFee() => feeStrategy.CalculateFee(this);

        public void Process()
        {
            if (!validator.Validate(this, out string error))
            {
                logger.Log($"Ошибка валидации транзакции {Id}: {error}", LogLevel.Error);
                return;
            }

            logger.Log($"Транзакция {Id}: Комиссия составила {Fee}.", LogLevel.Info);
            Execute(NetAmount);
            Notify();
        }

        public abstract void Cancel();

        protected abstract void Execute(decimal netAmount);
    }
}