namespace PresentationModel.Presenters
{
    public sealed class HeroStatsPresenterFactory
    {
        private readonly HeroExperienceBuyer _heroExperienceBuyer;
        private readonly MoneyStorage _moneyStorage;

        public HeroStatsPresenterFactory(HeroExperienceBuyer heroExperienceBuyer,
            MoneyStorage moneyStorage)
        {
            _heroExperienceBuyer = heroExperienceBuyer;
            _moneyStorage = moneyStorage;
        }

        public IHeroStatsPresenter Create(HeroInfo heroInfo)
        {
            return new HeroStatsPresenter(heroInfo, _moneyStorage, _heroExperienceBuyer);
        }
    }
}