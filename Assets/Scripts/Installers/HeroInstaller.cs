using Assets.Scripts.Experience;
using PresentationModel.Presenters;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public sealed class HeroInstaller : MonoInstaller
    {
        [SerializeField] private HeroStatsView _heroStatsView;
        public override void InstallBindings()
        {
            Container
                .Bind<HeroBuyer>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<HeroPresenterFactory>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<HeroExperienceBuyer>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<HeroStatsPresenterFactory>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<HeroStatsView>()
                .FromInstance(this._heroStatsView)
                .AsSingle();

            Container
                .Bind<ExperienceManager>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<Hero>()
                .AsTransient()
                .NonLazy();

            Container
                .Bind<HeroController>()
                .AsSingle()
                .NonLazy();
        }
    }
}