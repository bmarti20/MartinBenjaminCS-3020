using System;
using System.Collections.Generic;
using System.Text;

namespace HW2CharacterBattle
{
    public class Program
    {
        static Iplayerclass p1interface;
        static Iplayerclass p2interface;

        static void Main(string[] args)
        {
            string p1name, p2name;
            
            Console.WriteLine("***** Welcome to Medieval Combat! *****");
            Console.WriteLine("Player 1, enter your name: ");
            p1name = Console.ReadLine();
            Console.WriteLine("Player 2, enter your name: ");
            p2name = Console.ReadLine();                        // Gets player names 

            Console.WriteLine("\nClasses: ");                   // Displays Class Data
            Console.WriteLine("1. Warrior | 60 HP | 30 AP | 5 ATK | 8 SPATK  | 1 SPEED");
            Console.WriteLine("2. Archer  | 45 HP | 40 AP | 4 ATK | 10 SPATK | 3 SPEED");
            Console.WriteLine("3. Mage    | 40 HP | 50 AP | 3 ATK | 12 SPATK | 2 SPEED");

         p1choose:
            Console.Write("{0}, choose your class: ", p1name);
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) // Checks for invalid input
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                goto p1choose;
            }
            switch (choice)             // Sets the player interface to a class
            {
                case 1: p1interface = new Warrior(p1name); break; 
                case 2: p1interface = new Archer(p1name); break; 
                case 3: p1interface = new Mage(p1name); break; 
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    goto p1choose;
            }
            Character p1 = (Character)p1interface;      // Creates a character with the attributes from the interface

        p2choose:
            Console.Write("{0}, choose your class: ", p2name);
            if (!int.TryParse(Console.ReadLine(), out choice)) // Checks for invalid input
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                goto p2choose;
            }
            switch (choice)             // Sets the player interface to a class
            {
                case 1: p2interface = new Warrior(p2name); break;
                case 2: p2interface = new Archer(p2name); break;
                case 3: p2interface = new Mage(p2name); break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    goto p1choose;
            }
            Character p2 = (Character)p2interface;      // Creates a character with the attributes from the interface

            // My sincerest apologies to whoever reads this, this is the only way I could find that allows me to define
            // an object within a conditional statement. It feels really ugly and unnecessary, but it works. 

            if (p1.speed >= p2.speed)   // Calls the fight method based on who is faster
                fight(p1, p2);
            else
                fight(p2, p1);

            Console.ReadKey();
        }

        static void fight(Character first, Character second)
        {
            bool gameover = false;      // Program terminates when gameover is true
            int choice;
            while (!gameover)
            {
                Console.WriteLine("\n{0}: {1} HP, {2} AP  |  {3}: {4} HP, {5} AP",                // Displays health and ap for both players
                    first.name, first.health, first.ap, second.name, second.health, second.ap);

            firstaction:
                Console.WriteLine("{0}, choose your action:", first.name);
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Special Attack (requires 10 AP)");
                if (!int.TryParse(Console.ReadLine(), out choice)) // Checks for invalid input, gets choice from user
                {
                    Console.WriteLine("Invalid input. Please enter either 1 or 2.");
                    goto firstaction;
                }
                switch (choice)
                {
                    case 1: first.Attack(second); break;            // Attacks the enemy
                    case 2:
                        if (first.ap < 10)                          // Checks if the player has AP for a special attack
                        {
                            Console.WriteLine("You don't have enough AP for this action!");
                            goto firstaction;
                        }
                        else
                            first.SpAttack(second);                 // Special attacks the enemy
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter either 1 or 2.");
                        goto firstaction;                           // Input validation
                }
                if (second.health <= 0)     // Ends the game, displays message to the victor
                {
                    gameover = true;
                    Console.WriteLine("\n{0} has slain {1}. {0} wins!", first.name, second.name);
                    continue;
                }

                Console.WriteLine("\n{0}: {1} HP, {2} AP  |  {3}: {4} HP, {5} AP",                // Displays health and ap for both players
                    first.name, first.health, first.ap, second.name, second.health, second.ap);

            secondaction:
                Console.WriteLine("{0}, choose your action:", second.name);
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Special Attack (requires 10 AP)");
                if (!int.TryParse(Console.ReadLine(), out choice)) // Checks for invalid input, gets choice from user
                {
                    Console.WriteLine("Invalid input. Please enter either 1 or 2.");
                    goto secondaction;
                }
                switch (choice)
                {
                    case 1: second.Attack(first); break;            // Attacks the enemy
                    case 2:
                        if (second.ap < 10)                          // Checks if the player has AP for a special attack
                        {
                            Console.WriteLine("You don't have enough AP for this action!");
                            goto secondaction;
                        }
                        else
                            second.SpAttack(first);                 // Special attacks the enemy
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter either 1 or 2.");
                        goto secondaction;                           // Input validation
                }
                if (first.health <= 0)     // Ends the game, displays message to the victor
                {
                    gameover = true;
                    Console.WriteLine("\n{0} has slain {1}. {0} wins!", second.name, first.name);
                    continue;
                }
            }
        }
    }

    public abstract class Character : Iplayerclass      // Implements Iplayerclass interface, is inherited by Warrior, Mage, and Archer
    {
        private string _name;
        public string name{ get => _name; set => _name = value; }
        private string _spellname;
        public string spellname { get => _spellname; set => _spellname = value; }
        private int _health;
        public int health { get => _health; set => _health = value; }
        private int _ap;
        public int ap { get => _ap; set => _ap = value; }
        private int _speed;
        public int speed { get => _speed; set => _speed = value; }
        private char _Class;
        public char Class { get => _Class; set => _Class = value; }

        public abstract void Attack(Character enemy);
        public abstract void SpAttack(Character enemy);
        public abstract void TakeDamage(Character enemy);
        public abstract void TakeSpDamage(Character enemy);
    }

    public interface Iplayerclass       // Interface to be implemented by abstract class Character
    {
        string name { get; set; }
        string spellname { get; set; }
        int health { get; set; }
        int ap { get; set; }
        int speed { get; set; }
        char Class { get; set; }
        void Attack(Character enemy);
        void SpAttack(Character enemy);
        void TakeDamage(Character enemy);
        void TakeSpDamage(Character enemy);
    };

}