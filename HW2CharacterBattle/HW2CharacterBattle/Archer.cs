using System;
using System.Collections.Generic;
using System.Text;

namespace HW2CharacterBattle
{
    public class Archer : Character
    {
        public Archer(string name)      // Constructor that sets all the values for the Archer class
        {
            health = 45;
            ap = 40;
            Class = 'A';
            speed = 3;
            spellname = "Arrow Barrage";
            this.name = name;
        }

        public override void Attack(Character enemy)        // Deals regular damage to the enemy based on ATK stat
        {
            Console.WriteLine("{0} attacks {1}!", name, enemy.name);
            enemy.TakeDamage(this);
        }

        public override void SpAttack(Character enemy)      // Deals special damage to the enemy based on SpATK stat, costs 10 AP
        {
            ap -= 10;
            Console.WriteLine("{0} casts {1} on {2}! ({0} AP: {3})", name, spellname, enemy.name, ap);
            enemy.TakeSpDamage(this);
        }

        public override void TakeDamage(Character enemy)    // Takes regular damage based on enemy ATK stat
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

        public override void TakeSpDamage(Character enemy)  // Takes special damage based on enemy SpATK stat
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
