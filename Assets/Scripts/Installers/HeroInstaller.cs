using Assets.Scripts.Experience;
using PresentationModel.Presenters;
using Zenject;

namespace PresentationModel
{
    public sealed class HeroInstaller : MonoInstaller
    {
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