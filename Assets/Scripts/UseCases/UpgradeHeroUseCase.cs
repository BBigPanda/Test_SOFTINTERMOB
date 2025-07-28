using Cysharp.Threading.Tasks;
using Domain.Models;
using MessagePipe;
using Messaging.Signals;

namespace UseCases
{
    public class UpgradeHeroUseCase
    {
        private readonly HeroModel _hero;
        private readonly IPublisher<HeroUpgradedSignal> _heroUpgradedSignalPublisher;

        public UpgradeHeroUseCase(HeroModel hero, IPublisher<HeroUpgradedSignal> heroUpgradedSignalPublisher)
        {
            _hero = hero;
            _heroUpgradedSignalPublisher = heroUpgradedSignalPublisher;
        }

        public async UniTask Upgrade()
        {
            _hero.Upgrade();
            _heroUpgradedSignalPublisher.Publish(new HeroUpgradedSignal(_hero));
            await UniTask.Yield();
        }
    }
}