using SmartTransactionSystem.Interfaces;

namespace SmartTransactionSystem.Observers
{
    class NotificationService : ITransactionObserver
    {
        public void OnTransactionProcessed(string transactionId)
        {
            Console.WriteLine($"[NotificationService] Уведомление: транзакция {transactionId} обработана.");
        }
    }
}