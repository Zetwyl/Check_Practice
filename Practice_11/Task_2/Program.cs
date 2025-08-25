using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
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
                get
                {
                    if (index < 0 || index >= players.Length)
                    {
                        throw new IndexOutOfRangeException($"Индекс {index} выходит за границы массива");
                    }
                    return players[index];
                }
                set
                {
                    if (index < 0 || index >= players.Length)
                    {
                        throw new IndexOutOfRangeException($"Индекс {index} выходит за границы массива");
                    }
                    players[index] = value;
                }
            }
        }


        static void Main(string[] args)
        {
            Team inter = new Team();
            string[] playerNames = { "Player1", "Player2", "Player3", "Player4", "Player5",
                "Player6", "Player7", "Player8", "Player9", "Player10", "Player11" };

            for (int i = 0; i < 11; i++)
            {
                inter[i] = new Player { Name = playerNames[i], Number = i + 1 };
            }

            try
            {
                for (int i = 0; i < 11; i++)
                {
                    Player p = inter[i];
                    Console.WriteLine($"Name: {p.Name}, Number: {p.Number}");
                }

                inter[20] = new Player { Name = "Ronaldo", Number = 9 };
                //Console.WriteLine($"Name: {inter[-1]}, Number: {inter[-1].Name}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
