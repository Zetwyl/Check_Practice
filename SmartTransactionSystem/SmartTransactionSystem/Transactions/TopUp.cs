using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Validators;
using SmartTransactionSystem.Logging;

namespace SmartTransactionSystem.Transactions
{
    class TopUp : Transaction
    {
        protected override decimal MaxAmount => 1_000_000_000m;

        public TopUp(decimal amount, string id, TransactionValidator validator, IFeeStrategy feeStrategy, ILogger logger)
            : base(amount, id, validator, feeStrategy, logger) { }

        protected override void Execute(decimal netAmount)
        {
            logger.Log($"Пополнение {Id}: сумма {netAmount} обработана.", LogLevel.Info);
        }

        public override void Cancel()
        {
            logger.Log($"Пополнение {Id}: отменено.", LogLevel.Info);
        }
    }
}