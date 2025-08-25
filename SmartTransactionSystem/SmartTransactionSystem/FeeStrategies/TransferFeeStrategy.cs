using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Transactions;

namespace SmartTransactionSystem.FeeStrategies
{
    class TransferFeeStrategy : IFeeStrategy
    {
        public decimal CalculateFee(Transaction transaction)
        {
            return transaction.Amount * 0.01m; // 1%
        }
    }
}