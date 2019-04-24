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
            Console.WriteLine("\n{0} rolls!", p1.name);
            p1.changePosition(die.Next(1, 7));
            Console.WriteLine("{0} landed on {1}.", p1.name, tile[p1.position]);
            switch (p1.position)
            {
                case 1: propLand(p1, p2, Monopoly[0, 0]); break;      // All Property tiles grouped together
                case 2: propLand(p1, p2, Monopoly[0, 1]); break;
                case 4: propLand(p1, p2, Monopoly[0, 2]); break;
                case 6: propLand(p1, p2, Monopoly[1, 0]); break;
                case 7: propLand(p1, p2, Monopoly[1, 1]); break;
                case 9: propLand(p1, p2, Monopoly[1, 2]); break;
                case 11: propLand(p1, p2, Monopoly[2, 0]); break;
                case 12: propLand(p1, p2, Monopoly[2, 1]); break;
                case 14: propLand(p1, p2, Monopoly[2, 2]); break;
                case 16: propLand(p1, p2, Monopoly[3, 0]); break;
                case 17: propLand(p1, p2, Monopoly[3, 1]); break;
                case 19: propLand(p1, p2, Monopoly[3, 2]); break;
                case 3:                                         // Both Chance tiles grouped together
                case 13: chance(p1, p2); break;
                case 8:                                         // Both Community Chest tiles grouped together
                case 18: commChest(p1, p2); break;
                case 15: p1.goToJail(); break;             // Go to Jail tile sends player to Jail
                case 10: parking(p1); break;               // Player lands on Free Parking and collects the money there
                default: break;
            }
            Console.ReadKey();
        }

        static void propLand(Player player, Player other, Property prop)
        {

        }

        static void chance(Player player, Player other)     // Contains all the chance cards and selects them randomly. Needs both p1 and p2 for Property cards
        {
            Random rnd = new Random();
            int card = rnd.Next(1, 9);
            switch (card)
            {
                case 1:
                    Console.WriteLine("Advance to GO!");
                    player.setPosition(0);
                    break;
                case 2:
                    Console.WriteLine("Bank pays you dividend of $50!");
                    player.setMoney(50);
                    break;
                case 3:
                    Console.WriteLine("Get out of Jail Free!");
                    player.outofjailfree = true;
                    break;
                case 4:
                    Console.WriteLine("Go directly to Jail. Do not pass Go, do not collect $200.");
                    player.goToJail();
                    break;
                case 5:
                    Console.WriteLine("Pay $20 for each house you own and $50 for each hotel you own.");
                    if (player.houses == 0)
                        Console.WriteLine("You do not own any houses.");
                    else
                        player.setMoney(-20 * player.houses + -50 * player.hotels);
                    break;
                case 6:
                    Console.WriteLine("Advance to Atlantic Avenue. If you pass Go, collect $200.");
                    player.setPosition(11);
                    propLand(player, other, atlantic);
                    break;
                case 7:
                    Console.WriteLine("Advance to Connecticut Avenue. If you pass Go, collect $200.");
                    player.setPosition(4);
                    propLand(player, other, connecticut);
                    break;
                case 8:
                    Console.WriteLine("Pay a poor tax of $15");
                    player.setMoney(-15);
                    freeparking += 15;
                    break;
            }
        }

        static void commChest(Player player, Player other)      // Contains all the Community Chest cards, also needs p1 and p2
        {
            Random rnd = new Random();
            int card = rnd.Next(1, 9);
            switch (card)
            {
                case 1:
                    Console.WriteLine("Advance to Go!");
                    player.setPosition(0);
                    break;
                case 2:
                    Console.WriteLine("Get out of Jail Free!");
                    player.outofjailfree = true;
                    break;
                case 3:
                    Console.WriteLine("Go directly to Jail. Do not pass Go, do not collect $200.");
                    player.goToJail();
                    break;
                case 4:
                    Console.WriteLine("Pay $50 in doctor's fees");
                    player.setMoney(-50);
                    freeparking += 50;
                    break;
                case 5:
                    Console.WriteLine("You win 2nd in a beauty contest! Collect $10.");
                    player.setMoney(10);
                    break;
                case 6:
                    Console.WriteLine("Advance to Pennsylvania Avenue.");
                    player.setPosition(19);
                    propLand(player, other, pennsylvania);
                    break;
                case 7:
                    Console.WriteLine("Advance to New York Avenue. If you pass Go, collect $200.");
                    player.setPosition(9);
                    propLand(player, other, newyork);
                    break;
                case 8:
                    Console.WriteLine("Advance to Pacific Avenue. If you pass Go, collect $200.");
                    player.setPosition(16);
                    propLand(player, other, pacific);
                    break;

            }
        }

        static void parking(Player player)      // All money from fees (Chance cards, Jail fees, etc.) go to Free Parking. 1st player who lands on it gets the money
        {
            if (freeparking != 0)
            {
                Console.WriteLine("{0} collects the ${1} that was in Free Parking!", player.name, freeparking);
                player.setMoney(freeparking);
                freeparking = 0;
            }
        }

        static void listAllProps()
        {
            Console.WriteLine("\nProperty Name\t\tOwner\t\tRent\n");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("{0, -23} {1, -15} ${2}", Monopoly[i, j].name, Monopoly[i, j].owner, Monopoly[i, j].rent);
                }
            }
            Console.WriteLine();
        }
    }
}
