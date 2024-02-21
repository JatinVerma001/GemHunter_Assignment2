using System;

namespace GemHunter1
{
    public class Cell
    {
        public string Occupant { get; set; }

        public Cell(string occupant)
        {
            Occupant = occupant;
        }
    }

    public class Board
    {
        public Cell[,] Grid { get; }

        public Board()
        {
            Grid = new Cell[6, 6];
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new Cell("-");
                }
            }
            PlaceGems(7);
            PlaceObstacles(5);
        }
        private void PlaceGems(int numberOfGems)
        {
            Random random = new Random();

            for (int i = 0; i < numberOfGems; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(0, Grid.GetLength(0));
                    y = random.Next(0, Grid.GetLength(1));
                } while (Grid[x, y].Occupant != "-");

                Grid[x, y].Occupant = "G";
            }
        }
        private void PlaceObstacles(int numberOfObstacles)
        {
            Random random = new Random();

            for (int i = 0; i < numberOfObstacles; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(0, Grid.GetLength(0));
                    y = random.Next(0, Grid.GetLength(1));
                } while (Grid[x, y].Occupant != "-");

                Grid[x, y].Occupant = "X";
            }
        }

        public void Display()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write(Grid[i, j].Occupant + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Game
    {
        public Board Board { get; }

        public Game()
        {
            Board = new Board();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Gem Hunters! \n");
            DisplayBoard();
        }

        public void DisplayBoard()
        {
            Console.WriteLine("Current Board:");
            Board.Display();
        }
    }

    class Program
    {
        static void Main()
        {
            Game gemHunters = new Game();
            gemHunters.Start();
            Console.ReadLine();
        }
    }
}
