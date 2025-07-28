namespace Domain.Models
{
    public class HeroModel
    {
        public int Health { get; private set; } = 1;
        public int Mana { get; private set; } = 1;
        public int Power { get; private set; } = 1;

        public void Upgrade()
        {
            Health++;
            Mana += 2;
            Power += 10;
        }
    }
}