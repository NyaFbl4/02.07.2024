using UniRx;

namespace PresentationModel
{
    public sealed class HeroStatsPresenter : IHeroStatsPresenter
    {
        private readonly HeroInfo _heroInfo;
        private readonly HeroExperienceBuyer _heroExperienceBuyer;
        private readonly CompositeDisposable _compositeDisposable = new();
        
        public string Lvl    { get; }
        public string Health { get; }
        public string Attack { get; }
        
        public ReactiveCommand LvlUp { get; }
        private readonly ReactiveProperty<bool> _canBuy = new BoolReactiveProperty();
        public  IReadOnlyReactiveProperty<bool> CanBuy => _canBuy;
        public IReadOnlyReactiveProperty<long> Money;
        
        public HeroStatsPresenter(HeroInfo heroInfo, MoneyStorage moneyStorage, 
                                  HeroExperienceBuyer heroExperienceBuyer)
        {
            _heroInfo = heroInfo;
            _heroExperienceBuyer = heroExperienceBuyer;
            
            Lvl        = _heroInfo.Lvl.ToString();
            Health     = _heroInfo.Health.ToString();
            Attack     = _heroInfo.Attack.ToString();
            
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