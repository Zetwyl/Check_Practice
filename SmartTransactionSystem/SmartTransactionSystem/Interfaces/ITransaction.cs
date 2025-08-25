namespace SmartTransactionSystem.Interfaces
{
    interface ITransaction
    {
        void Process();
        void Cancel();
        decimal Amount { get; }
        string Id { get; }
        decimal CalculateFee();
    }
}