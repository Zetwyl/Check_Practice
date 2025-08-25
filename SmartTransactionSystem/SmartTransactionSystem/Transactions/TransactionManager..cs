using SmartTransactionSystem.Interfaces;

namespace SmartTransactionSystem.Transactions
{
    class TransactionManager
    {
        private List<ICommand> history = new List<ICommand>();
        private int currentIndex = -1;

        public void Execute(ICommand command)
        {
            // Удалим все "повторённые" действия, если были Undo
            if (currentIndex < history.Count - 1)
            {
                history.RemoveRange(currentIndex + 1, history.Count - currentIndex - 1);
            }

            command.Execute();
            history.Add(command);
            currentIndex++;
        }

        public void Undo()
        {
            if (currentIndex >= 0)
            {
                history[currentIndex].Undo();
                currentIndex--;
            }
            else
            {
                Console.WriteLine("❌ Нет транзакций для отмены.");
            }
        }

        public void Redo()
        {
            if (currentIndex + 1 < history.Count)
            {
                currentIndex++;
                history[currentIndex].Redo();
            }
            else
            {
                Console.WriteLine("❌ Нет транзакций для повтора.");
            }
        }
    }
}
