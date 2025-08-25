using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Transactions;

namespace SmartTransactionSystem.Validators
{
    class MaxAmountRule : IValidationRule
    {
        public string ErrorMessage => $"Сумма платежа превышает максимально допустимый лимит";

        public bool Validate(Transaction transaction)
        {
            return transaction.Amount <= transaction.MaxAllowedAmount;
        }
    }
}