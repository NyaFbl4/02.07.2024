namespace PresentationModel
{
    public sealed class HeroPresenterFactory
    {
        private readonly HeroBuyer _heroBuyer;
        private readonly MoneyStorage _moneyStorage;

        public HeroPresenterFactory(HeroBuyer heroBuyer, MoneyStorage moneyStorage)
        {
            _heroBuyer = heroBuyer;
            _moneyStorage = moneyStorage;
        }

        public IHeroPresenter Create(HeroInfo heroInfo)
        {
            return new HeroPresenter(heroInfo, _heroBuyer, _moneyStorage);
        }
    }
}