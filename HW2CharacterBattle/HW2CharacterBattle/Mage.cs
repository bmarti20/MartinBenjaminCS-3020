using System;
using System.Collections.Generic;
using System.Text;

namespace HW2CharacterBattle
{
    public class Mage : Character
    {
        public Mage(string name)
        {
            health = 30;
            ap = 50;
            Class = 'M';
            speed = 2;
            spellname = "Arcane Missiles";
            this.name = name;
        }

        public override void Attack(Character enemy)
        {
            Console.WriteLine("{0} attacks {1}!", name, enemy.name);
            enemy.TakeDamage(this);
        }

        public override void SpAttack(Character enemy)
        {
            ap -= 10;
            Console.WriteLine("{0} casts {1} on {2}! ({0} AP: {3})", name, spellname, enemy.name, ap);
            enemy.TakeSpDamage(this);
        }

        public override void TakeDamage(Character enemy)
        {
            switch (enemy.Class)
            {
                case 'W':
                    health -= 5;
                    Console.WriteLine("{0} takes 5 damage! (HP {1})", name, health);
                    break;
                case 'A':
                    health -= 4;
                    Console.WriteLine("{0} takes 4 damage! (HP {1})", name, health);
                    break;
                case 'M':
                    health -= 3;
                    Console.WriteLine("{0} takes 3 damage! (HP {1})", name, health);
                    break;
                default: break;
            }
        }

        public override void TakeSpDamage(Character enemy)
        {
            switch (enemy.Class)
            {
                case 'W':
                    health -= 8;
                    Console.WriteLine("{0} takes 8 damage! (HP {1})", name, health);
                    break;
                case 'A':
                    health -= 10;
                    Console.WriteLine("{0} takes 10 damage! (HP {1})", name, health);
                    break;
                case 'M':
                    health -= 12;
                    Console.WriteLine("{0} takes 12 damage! (HP {1})", name, health);
                    break;
                default: break;
            }
        }
    }
}
