using SmartTransactionSystem.Interfaces;

namespace SmartTransactionSystem.Observers
{
    class SmsNotifier : ITransactionObserver
    {
        public void OnTransactionProcessed(string transactionId)
        {
            Console.WriteLine($"[SmsNotifier] Отправлено SMS-уведомление о транзакции {transactionId}.");
        }
    }
}