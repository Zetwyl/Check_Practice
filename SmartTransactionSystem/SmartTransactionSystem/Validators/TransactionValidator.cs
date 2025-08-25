using SmartTransactionSystem.Interfaces;
using SmartTransactionSystem.Transactions;

namespace SmartTransactionSystem.Validators
{
    class TransactionValidator
    {
        private List<IValidationRule> rules;

        public TransactionValidator(List<IValidationRule> rules)
        {
            this.rules = rules;
        }

        public bool Validate(Transaction transaction, out string error)
        {
            foreach (var rule in rules)
            {
                if (!rule.Validate(transaction))
                {
                    error = rule.ErrorMessage;
                    return false;
                }
            }
            error = null;
            return true;
        }
    }
}