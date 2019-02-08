using System;
using System.Collections.Generic;
using System.Text;

namespace HW2CharacterBattle
{
    public class Program
    {
        static void Main(string[] args)
        {
            string p1name, p2name;
            Console.WriteLine("***** Welcome to Medieval Combat! *****");
            Console.WriteLine("Player 1, enter your name: ");
            p1name = Console.ReadLine();
            Console.WriteLine("Player 2, enter your name: ");
            p2name = Console.ReadLine();

            Console.WriteLine("\nClasses: ");
            Console.WriteLine("1. Warrior | 60 HP | 30 AP | 5 ATK | 8 SPATK  | 1 SPEED");
            Console.WriteLine("2. Archer  | 50 HP | 40 AP | 4 ATK | 10 SPATK | 3 SPEED");
            Console.WriteLine("3. Mage    | 40 HP | 50 AP | 3 ATK | 12 SPATK | 2 SPEED");

            Warrior war = new Warrior("Charles");
            Archer arc = new Archer("Will");
            Mage mag = new Mage("Merlin");

            Console.ReadKey();
        }
    }

    public abstract class Character
    {
        public string name;
        public int health;
        public int ap;
        public int speed;
        public char Class;
        public void Attack(Character enemy) { enemy.TakeDamage(this); }
        public void SpAttack(Character enemy)
        {
            if (ap != 0)
            {
                enemy.TakeSpDamage(this);
                ap -= 10;
            }
        }
        public abstract void TakeDamage(Character enemy);
        public abstract void TakeSpDamage(Character enemy);
    }

}