using SmartTransactionSystem.Interfaces;

namespace SmartTransactionSystem.Observers
{
    class EmailNotifier : ITransactionObserver
    {
        public void OnTransactionProcessed(string transactionId)
        {
            Console.WriteLine($"[EmailNotifier] Отправлено email-уведомление о транзакции {transactionId}.");
        }
    }
}