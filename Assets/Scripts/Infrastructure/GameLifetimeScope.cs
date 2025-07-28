using System;
using System.ComponentModel;
using Domain.Models;
using MessagePipe;
using UI.Presenters;
using UI.Views;
using UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HeroView _heroView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<HeroModel>(Lifetime.Singleton);
            builder.Register<UpgradeHeroUseCase>(Lifetime.Singleton);
            builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<UpgradeHeroUseCase>(options: new MessagePipeOptions());
            builder.RegisterInstance<IHeroView>(_heroView);
            builder.Register<HeroPresenter>(Lifetime.Singleton);
        }

        protected void Start()
        {
            HeroPresenter presenter = Container.Resolve<HeroPresenter>();
            HeroView view = Container.Resolve<IHeroView>() as HeroView;
            view.Initialize(presenter);
        }
    }
}