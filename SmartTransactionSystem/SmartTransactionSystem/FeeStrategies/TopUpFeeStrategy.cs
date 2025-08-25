using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Transactions;

namespace SmartTransactionSystem.FeeStrategies
{
    class TopUpFeeStrategy : IFeeStrategy
    {
        public decimal CalculateFee(Transaction transaction)
        {
            return 0m; // Без комиссии
        }
    }
}