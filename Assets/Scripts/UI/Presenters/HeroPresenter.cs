using System;
using MessagePipe;
using Messaging.Signals;
using UI.Views;
using UseCases;

namespace UI.Presenters
{
    public class HeroPresenter: IDisposable
    {
        private readonly UpgradeHeroUseCase _upgradeHeroUseCase;
        private readonly IHeroView _heroView;
        private readonly IDisposable _disposable;


        public HeroPresenter(UpgradeHeroUseCase upgradeHeroUseCase, IHeroView heroView, ISubscriber<HeroUpgradedSignal> subscriber)
        {
            _upgradeHeroUseCase = upgradeHeroUseCase;
            _heroView = heroView;
            _disposable = subscriber.Subscribe(OnHeroUpgradedSignal);
        }

        private void OnHeroUpgradedSignal(HeroUpgradedSignal signal)
        {
            var hero = signal.Hero;
            _heroView.SetValues(hero.Health, hero.Mana, hero.Power);
        }

        public async void OnUpgradeButtonClicked()
        {
            await _upgradeHeroUseCase.Upgrade();
        }

        public void Dispose()
        {
          _disposable.Dispose();
        }
    }
}