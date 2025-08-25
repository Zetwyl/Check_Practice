using SmartTransactionSystem.Facades;

namespace SmartTransactionSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = new TransactionFacade();

            Console.WriteLine("=== Payment ===");
            facade.ProcessPayment(50_000, "PAY1001");

            Console.WriteLine("\n=== Transfer (с ошибкой) ===");
            facade.ProcessTransfer(600_000, "TRF2001");

            Console.WriteLine("\n=== Transfer (без ошибки) ===");
            facade.ProcessTransfer(300_000, "TRF2002");
            facade.ProcessTransfer(300_000, "TRF2002"); // Повтор выполнения

            Console.WriteLine("\n=== TopUp ===");
            facade.ProcessTopUp(2_000_000, "TOP3001");
            facade.ProcessTopUp(2_000_000, "TOP3001"); // Повтор выполнения

            Console.WriteLine("\nОтмена последней транзакции:");
            facade.Undo();

            Console.WriteLine("\nПовтор последней транзакции:");
            facade.Redo();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}

