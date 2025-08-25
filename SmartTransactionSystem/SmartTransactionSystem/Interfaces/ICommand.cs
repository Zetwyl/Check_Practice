namespace SmartTransactionSystem.Interfaces
{
    interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }
}
