namespace PresentationModel.Presenters
{
    public sealed class HeroStatsPresenterFactory
    {
        private readonly HeroExperienceBuyer _heroExperienceBuyer;
        private readonly MoneyStorage _moneyStorage;
        private readonly ExperienceManager _experienceManager;

        public HeroStatsPresenterFactory(HeroExperienceBuyer heroExperienceBuyer,
            MoneyStorage moneyStorage, ExperienceManager experienceManager)
        {
            _heroExperienceBuyer = heroExperienceBuyer;
            _moneyStorage = moneyStorage;
            _experienceManager = experienceManager;
        }

        public IHeroStatsPresenter Create(HeroInfo heroInfo)
        {
            return new HeroStatsPresenter(heroInfo, _moneyStorage, 
                _heroExperienceBuyer, _experienceManager);
        }
    }
}