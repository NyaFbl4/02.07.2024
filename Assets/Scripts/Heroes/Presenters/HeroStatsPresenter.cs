using UniRx;


namespace PresentationModel
{
    public sealed class HeroStatsPresenter : IHeroStatsPresenter
    {
        public string Lvl    { get; }
        public string Health { get; }
        public string Attack { get; }
        public string PriceGold  { get; }
        public string CurrentExperience { get; }
        public ReactiveCommand LvlUp { get; }
        
        public IReadOnlyReactiveProperty<bool> CanBuy => _canBuy;
        private readonly ReactiveProperty<bool> _canBuy = new BoolReactiveProperty();
        
        private readonly HeroInfo _heroInfo;
        private readonly HeroExperienceBuyer _heroExperienceBuyer;
        private readonly CompositeDisposable _compositeDisposable = new();

        private ExperienceManager _experienceManager;
        
        public IReadOnlyReactiveProperty<long> Money;

        public HeroStatsPresenter(HeroInfo heroInfo, MoneyStorage moneyStorage, 
                                  HeroExperienceBuyer heroExperienceBuyer,
                                  ExperienceManager experienceManager)
        {
            _heroInfo            = heroInfo;
            _heroExperienceBuyer = heroExperienceBuyer;
            _experienceManager   = experienceManager;
            
            Lvl               = _heroInfo.Lvl.ToString();
            Health            = _heroInfo.Health.ToString();
            Attack            = _heroInfo.Attack.ToString();
            PriceGold         = _heroInfo.MoneyPrice.ToString();
            CurrentExperience = _heroInfo.CurrentExperience.ToString();
            _experienceManager.TakeExpirience(_heroInfo.CurrentExperience);
            
            moneyStorage.Money.Subscribe(UpdateCanBuy).AddTo(_compositeDisposable);
            LvlUp = new ReactiveCommand(CanBuy);
            LvlUp.Subscribe(OnBuyCommand).AddTo(_compositeDisposable);
            
            Money = moneyStorage.Money;
        }

        ~HeroStatsPresenter()
        {
            _compositeDisposable.Dispose();
        }
        private void UpdateCanBuy(long _)
        {
            _canBuy.Value = _heroExperienceBuyer.CanBuy(_heroInfo);
        }
        private void OnBuyCommand(Unit _)
        {
            Buy();
        }
        public void Buy()
        {
            if (CanBuy.Value)
            {
                _heroExperienceBuyer.BuyExperience(_heroInfo);
            }
        }
    }
}