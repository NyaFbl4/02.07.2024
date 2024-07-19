using UniRx;
using UnityEngine;

namespace PresentationModel
{
    public class HeroPresenter : IHeroPresenter
    {
        public string Name   { get; }
        public string Lvl    { get; }
        public string Health { get; }
        public string Attack { get; }
        public Sprite Icon   { get; }
        public string PriceGold  { get; }

        public ReactiveCommand BuyCommand { get; }
        
        public  IReadOnlyReactiveProperty<bool> CanBuy => _canBuy;
        private readonly ReactiveProperty<bool> _canBuy = new BoolReactiveProperty();

        private readonly HeroInfo _heroInfo;
        private readonly HeroBuyer _heroBuyer;
        private readonly CompositeDisposable _compositeDisposable = new();

        public IReadOnlyReactiveProperty<long> Money;

        public HeroPresenter(HeroInfo heroInfo, HeroBuyer heroBuyer, MoneyStorage moneyStorage)
        {
            _heroInfo  = heroInfo;
            _heroBuyer = heroBuyer;
            Name       = _heroInfo.Name;
            Lvl        = _heroInfo.Lvl.ToString();
            Health     = _heroInfo.Health.ToString();
            Attack     = _heroInfo.Attack.ToString();
            Icon       = _heroInfo.Icon;
            PriceGold  = _heroInfo.MoneyPrice.ToString();

            moneyStorage.Money.Subscribe(UpdateCanBuy).AddTo(_compositeDisposable);
            BuyCommand = new ReactiveCommand(CanBuy);
            BuyCommand.Subscribe(OnBuyCommand).AddTo(_compositeDisposable);
            BuyCommand.Pairwise().Subscribe(OnNext).AddTo(_compositeDisposable);
            Money = moneyStorage.Money;
        }

        ~HeroPresenter()
        {
            _compositeDisposable.Dispose();
        }

        private void UpdateCanBuy(long _)
        {
            _canBuy.Value = _heroBuyer.CanBuy(_heroInfo);
        }

        private void OnBuyCommand(Unit _)
        {
            Buy();
        }
        
        private void OnNext(Pair<Unit> obj)
        {
        }
        
        public void Buy()
        {
            if (CanBuy.Value)
            {
                _heroBuyer.Buy(_heroInfo);
            }
        }
    }
}