using SmartTransactionSystem.FeeStrategies;
using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Logging;
using SmartTransactionSystem.Observers;
using SmartTransactionSystem.Transactions;
using SmartTransactionSystem.Validators;

namespace SmartTransactionSystem.Facades
{
    class TransactionFacade
    {
        private readonly ILogger logger;
        private readonly TransactionValidator validator;
        private readonly List<ITransactionObserver> observers;
        private readonly TransactionManager transactionManager;

        private readonly Dictionary<string, ITransaction> decoratedTransactions = new Dictionary<string, ITransaction>();

        public TransactionFacade()
        {
            logger = Logger.Instance;

            var validationRules = new List<IValidationRule>
            {
                new AmountPositiveRule(),
                new MaxAmountRule()
            };
            validator = new TransactionValidator(validationRules);

            observers = new List<ITransactionObserver>
            {
                new NotificationService(),
                new EmailNotifier(),
                new SmsNotifier()
            };

            transactionManager = new TransactionManager();
        }

        public void ProcessPayment(decimal amount, string id)
        {
            ITransaction decorated;
            if (!decoratedTransactions.ContainsKey(id))
            {
                var payment = new Payment(amount, id, validator, new PaymentFeeStrategy(), logger);
                SubscribeObservers(payment);
                decorated = DecorateTransaction(payment);
                decoratedTransactions[id] = decorated;
            }
            else
            {
                decorated = decoratedTransactions[id];
            }

            var command = new TransactionCommand(decorated, logger);
            transactionManager.Execute(command);
        }

        public void ProcessTransfer(decimal amount, string id)
        {
            ITransaction decorated;
            if (!decoratedTransactions.ContainsKey(id))
            {
                var transfer = new Transfer(amount, id, validator, new TransferFeeStrategy(), logger);
                SubscribeObservers(transfer);
                decorated = DecorateTransaction(transfer);
                decoratedTransactions[id] = decorated;
            }
            else
            {
                decorated = decoratedTransactions[id];
            }

            var command = new TransactionCommand(decorated, logger);
            transactionManager.Execute(command);
        }

        public void ProcessTopUp(decimal amount, string id)
        {
            ITransaction decorated;
            if (!decoratedTransactions.ContainsKey(id))
            {
                var topUp = new TopUp(amount, id, validator, new TopUpFeeStrategy(), logger);
                SubscribeObservers(topUp);
                decorated = DecorateTransaction(topUp);
                decoratedTransactions[id] = decorated;
            }
            else
            {
                decorated = decoratedTransactions[id];
            }

            var command = new TransactionCommand(decorated, logger);
            transactionManager.Execute(command);
        }

        public void Undo() => transactionManager.Undo();
        public void Redo() => transactionManager.Redo();

        private void SubscribeObservers(Transaction transaction)
        {
            foreach (var obs in observers)
            {
                transaction.Subscribe(obs);
            }
        }

        private ITransaction DecorateTransaction(Transaction transaction)
        {
            return new LoggingTransactionDecorator(new CachingTransactionDecorator(transaction, logger), logger);
        }
    }
}
