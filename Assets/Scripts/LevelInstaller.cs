using Zenject;

namespace MVP
{
    public sealed class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var view = FindObjectOfType<CurrencyViewProvider>();
            MoneyBind(view.MoneyView);
            //GemBind(view.GemView);
        }

        private void MoneyBind(CurrencyView view)
        {
            Container
                .Bind<MoneyStorage>()
                .AsSingle()
                .WithArguments(10L)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<MoneyObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy(); 
        }

        /*
        private void GemBind(CurrencyView view)
        {
            Container
                .Bind<GemStorage>()
                .AsSingle()
                .WithArguments(1l)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GemObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy(); 
        }
        */
    }
}