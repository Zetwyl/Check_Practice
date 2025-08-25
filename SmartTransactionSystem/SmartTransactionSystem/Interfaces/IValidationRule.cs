using SmartTransactionSystem.Transactions;

namespace SmartTransactionSystem.Interfaces
{
    interface IValidationRule
    {
        bool Validate(Transaction transaction);
        string ErrorMessage { get; }
    }
}