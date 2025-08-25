using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Transactions;

namespace SmartTransactionSystem.FeeStrategies
{
    class PaymentFeeStrategy : IFeeStrategy
    {
        public decimal CalculateFee(Transaction transaction)
        {
            return transaction.Amount * 0.015m; // 1.5%
        }
    }
}