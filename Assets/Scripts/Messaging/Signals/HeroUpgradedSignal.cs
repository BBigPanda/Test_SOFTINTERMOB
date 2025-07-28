using Domain.Models;

namespace Messaging.Signals
{
    public class HeroUpgradedSignal
    {
        public HeroModel Hero { get; }

        public HeroUpgradedSignal(HeroModel hero)
        {
            Hero = hero;
        }
    }
}