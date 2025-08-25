namespace SmartTransactionSystem.Interfaces
{
    interface ITransactionObserver
    {
        void OnTransactionProcessed(string transactionId);
    }
}