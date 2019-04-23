using System;
using System.Collections.Generic;

namespace FinalProject
{
    class Program
    {
        // Money that players will start with
        const int STARTMONEY = 1000;

        // Instantiates objects for Player 1 and Player 2
        public static Player p1;
        public static Player p2;

        // All tile names
        public static String[] tile = { "Go!", "Oriental Avenue", "Vermont Avenue",  "Chance",  "Connecticut Avenue",
            "Jail",  "St. James Place",  "Tennessee Avenue",  "Community Chest",  "New York Avenue",  "Free Parking",
            "Atlantic Avenue",  "Ventnor Avenue",  "Chance",  "Marvin Gardens",  "Go To Jail",  "Pacific Avenue",
            "North Carolina Avenue", "Community Chest",  "Pennsylvania Avenue"};

        // Starting value for Free Parking
        public static int freeparking = 0;

        // Properties
        public static Property oriental = new Property(tile[1], 100, 6, 50, 1, "blue");
        public static Property vermont = new Property(tile[2], 100, 6, 50, 2, "blue");
        public static Property connecticut = new Property(tile[4], 120, 8, 50, 4, "blue");
        public static Property stjames = new Property(tile[6], 180, 14, 100, 6, "yellow");
        public static Property tennessee = new Property(tile[7], 180, 14, 100, 7, "yellow");
        public static Property newyork = new Property(tile[9], 200, 16, 100, 9, "yellow");
        public static Property atlantic = new Property(tile[11], 260, 22, 150, 11, "red");
        public static Property ventnor = new Property(tile[12], 260, 22, 150, 12, "red");
        public static Property marvin = new Property(tile[14], 280, 24, 150, 14, "red");
        public static Property pacific = new Property(tile[16], 340, 30, 200, 16, "green");
        public static Property carolina = new Property(tile[17], 340, 30, 200, 17, "green");
        public static Property pennsylvania = new Property(tile[19], 360, 32, 200, 18, "green");

        public static Property[,] Monopoly = new Property[4, 3];        // 2D array of Properties keeps track of monopolies

        static void Main(string[] args)
        {
            Monopoly[0, 0] = oriental; Monopoly[0, 1] = vermont; Monopoly[0, 2] = connecticut;      // Blue Properties
            Monopoly[1, 0] = stjames; Monopoly[1, 1] = tennessee; Monopoly[1, 2] = newyork;         // Yellow Properties
            Monopoly[2, 0] = atlantic; Monopoly[2, 1] = ventnor; Monopoly[2, 2] = marvin;           // Red Properties
            Monopoly[3, 0] = pacific; Monopoly[3, 1] = carolina; Monopoly[3, 2] = pennsylvania;     // Green Properties

            Console.WriteLine("***** Welcome to Mini-opoly! *****");
        StartRules:
            Console.WriteLine("Press 'r' to show the rules, or 's' to start the game!");
            char choice = char.Parse(Console.ReadLine());
            switch (choice)
            {
                case 's':
                case 'S': break;
                case 'r':
                case 'R': showrules();
                    goto StartRules;
                default: Console.WriteLine("Error, invalid input.");
                    goto StartRules;
            }

            Console.Write("Player 1, please enter your name: ");
            p1 = new Player(Console.ReadLine(), STARTMONEY);
            Console.Write("Player 2, please enter your name: ");
            p2 = new Player(Console.ReadLine(), STARTMONEY);
            play(p1, p2);

            Console.ReadKey();
        }

        static void showrules()
        {
            string[] lines = System.IO.File.ReadAllLines("Mini-opoly Rules.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }

        static void play(Player p1, Player p2)
        {
            bool gameover = false;

            while (!gameover)
            {
                roll(p1, p2);
                if (p1.money <= 0)
                {
                    Console.WriteLine("{0} is bankrupt. {1} wins!", p1.name, p2.name);
                    gameover = true;
                    continue;
                }
                roll(p2, p1);
                if (p1.money <= 0)
                {
                    Console.WriteLine("{0} is bankrupt. {1} wins!", p2.name, p1.name);
                    gameover = true;
                }
            }
            Console.WriteLine("Game Over.");
        }

        static void roll(Player p1, Player p2)
        {
            Random die = new Random();
            Console.WriteLine("{0} rolls!", p1.name);
            p1.changePosition(die.Next(1, 7));
            Console.WriteLine("{0} landed on {1}.", p1.name, tile[p1.position]);
            Console.ReadKey();
        }
    }
}
