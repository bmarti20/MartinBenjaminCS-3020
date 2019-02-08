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
            this.name = name;
        }

        public override void TakeDamage(Character enemy)
        {
            switch (enemy.Class)
            {
                case 'W': health -= 5; break;
                case 'A': health -= 15; break;
                case 'M': health -= 10; break;
                default: break;
            }
        }

        public override void TakeSpDamage(Character enemy)
        {

        }
    }
}
