namespace HW2CharacterBattle
{
    public class Archer : Character
    {
        public Archer(string name)
        {
            health = 40;
            ap = 40;
            Class = 'A';
            speed = 3;
            this.name = name;
        }

        public override void TakeDamage(Character enemy)
        {
            switch (enemy.Class)
            {
                case 'W': health -= 15; break;
                case 'A': health -= 10; break;
                case 'M': health -= 5; break;
                default: break;
            }
        }

        public override void TakeSpDamage(Character enemy)
        {

        }
    }
}
