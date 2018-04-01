namespace _03BarracksFactory.Models.Units
{
    public class Swordsman : Unit
    {
        private const int DefaultHealth = 40;
        private const int DefaultDamage = 13;

        public Swordsman()
            : base(DefaultHealth, DefaultDamage)
        {

        }
    }
}
