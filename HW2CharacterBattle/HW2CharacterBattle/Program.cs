using System;

namespace HW2CharacterBattle
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Character
    {
        protected string name;
        public abstract void Attack();
    }

    public class Warrior : Character
    {
        public Warrior(string name)
        {
            this.name = name;
        }

        public override void Attack()
        {

        }
    }

    public class Archer : Character
    {
        public Archer(string name)
        {
            this.name = name;
        }

        public override void Attack()
        {

        }
    }

    public class Mage : Character
    {
        public Mage(string name)
        {
            this.name = name;
        }

        public override void Attack()
        {

        }
    }
}
