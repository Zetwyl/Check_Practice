using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Transactions;

namespace SmartTransactionSystem.Validators
{
    class AmountPositiveRule : IValidationRule
    {
        public string ErrorMessage => "Сумма должна быть больше 0";

        public bool Validate(Transaction transaction)
        {
            return transaction.Amount > 0;
        }
    }
}