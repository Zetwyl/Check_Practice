namespace Task_1
{
    internal class Program
    {
        class Player
        {
            public string Name { get; set; }
            public int Number { get; set; }
        }
        class Team
        {
            Player[] players = new Player[11];

            public Player this[int index]
            {
                get => players[index];
                set => players[index] = value;
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
