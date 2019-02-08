namespace HW2CharacterBattle
{
    public class Warrior : Character
    {
        public Warrior(string name)
        {        
            health = 50;
            ap = 30;
            Class = 'W';
            speed = 1;
            this.name = name;
        }

        public override void TakeDamage(Character enemy)
        {
            switch (enemy.Class)
            {
                case 'W': health -= 10; break;
                case 'A': health -= 5; break;
                case 'M': health -= 15; break;
                default: break;
            }
        }

        public override void TakeSpDamage(Character enemy)
        {
            
        }
    }
}
