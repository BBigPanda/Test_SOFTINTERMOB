using Domain.Models;
using MessagePipe;
using UseCases;
using VContainer;
using VContainer.Unity;
using Messaging.Signals;

namespace Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<HeroModel>(Lifetime.Singleton);
            builder.Register<UpgradeHeroUseCase>(Lifetime.Singleton);
            builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<UpgradeHeroUseCase>(options: new MessagePipeOptions());
        }
    }
}