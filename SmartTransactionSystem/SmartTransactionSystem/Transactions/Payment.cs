using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Validators;
using SmartTransactionSystem.Logging;

namespace SmartTransactionSystem.Transactions
{
    class Payment : Transaction
    {
        protected override decimal MaxAmount => 100_000m;

        public Payment(decimal amount, string id, TransactionValidator validator, IFeeStrategy feeStrategy, ILogger logger)
            : base(amount, id, validator, feeStrategy, logger) { }

        protected override void Execute(decimal netAmount)
        {
            logger.Log($"Платёж {Id}: сумма {netAmount} обработана.", LogLevel.Info);
        }

        public override void Cancel()
        {
            logger.Log($"Платёж {Id}: отменён.", LogLevel.Info);
        }
    }
}