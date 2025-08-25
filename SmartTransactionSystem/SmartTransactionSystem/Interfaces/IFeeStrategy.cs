using SmartTransactionSystem.Transactions;

namespace SmartTransactionSystem.Interfaces
{
    interface IFeeStrategy
    {
        decimal CalculateFee(Transaction transaction);
    }
}