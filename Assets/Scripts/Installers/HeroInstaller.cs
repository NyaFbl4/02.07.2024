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
        }
    }
}