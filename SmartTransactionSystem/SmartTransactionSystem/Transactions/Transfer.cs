using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Validators;
using SmartTransactionSystem.Logging;

namespace SmartTransactionSystem.Transactions
{
    class Transfer : Transaction
    {
        protected override decimal MaxAmount => 500_000m;

        public Transfer(decimal amount, string id, TransactionValidator validator, IFeeStrategy feeStrategy, ILogger logger)
            : base(amount, id, validator, feeStrategy, logger) { }

        protected override void Execute(decimal netAmount)
        {
            logger.Log($"������� {Id}: ����� {netAmount} ����������.", LogLevel.Info);
        }

        public override void Cancel()
        {
            logger.Log($"������� {Id}: ������.", LogLevel.Info);
        }
    }
}