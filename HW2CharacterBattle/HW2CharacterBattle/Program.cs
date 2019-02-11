using System;
using System.Collections.Generic;
using System.Text;

namespace HW2CharacterBattle
{
    public class Program
    {
        static Iplayerclass p1;

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
            Console.WriteLine("2. Archer  | 50 HP | 40 AP | 4 ATK | 10 SPATK | 3 SPEED");
            Console.WriteLine("3. Mage    | 40 HP | 50 AP | 3 ATK | 12 SPATK | 2 SPEED");

         p1choose:
            Console.Write("{0}, choose your class: ", p1name);
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) // Checks for invalid input
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                goto p1choose;
            }

            

            if (choice == 1)
                p1 = new Warrior(p1name);

            Console.WriteLine(p1.name.ToString());
            

            //switch (choice)             // Creates an instance of a class with p1's name
            //{
            //    case 1: Warrior p1 = new Warrior(p1name); break; 
            //    case 2: Archer p1 = new Archer(p1name); break; 
            //    case 3: Mage p1 = new Mage(p1name); break; 
            //    default:
            //        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            //        goto p1choose;
            //}
            
            
         p2choose:
            Console.Write("{0}, choose your class: ", p2name);
            if (!int.TryParse(Console.ReadLine(), out choice)) // Checks for invalid input
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                goto p2choose;
            }
            //switch (choice)             // Creates an instance of a class with p2's name
            //{
            //    case 1: { Warrior p2 = new Warrior(p1name); break; }
            //    case 2: { Archer p2 = new Archer(p1name); break; }
            //    case 3: { Mage p2 = new Mage(p1name); break; }
            //    default:
            //        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            //        goto p2choose;
            //}
            
            // Normally I would put these into a method and call that for p1 and p2, but since I need the p1 and p2 objects to be 
            // unique, I can't think of a better way to do it :/ sorry for the ugly code!

            

            Console.ReadKey();
        }
    }

    public abstract class Character : Iplayerclass
    {
        //public string name;
        public string spellname;
        public int health;
        public int ap;
        public int speed;
        public char Class;

        private string _name;
        public string name { get => _name; set => _name = value; }

        public abstract void Attack(Character enemy);
        public abstract void SpAttack(Character enemy);
        public abstract void TakeDamage(Character enemy);
        public abstract void TakeSpDamage(Character enemy);
    }

    public interface Iplayerclass
    {
        string name { get; set; }
    };

}