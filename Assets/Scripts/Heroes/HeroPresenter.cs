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
        public string Price  { get; }
        
        public ReactiveCommand BuyCommand { get; }
        
        public  IReadOnlyReactiveProperty<bool> CanBuy => _canBuy;
        private readonly ReactiveProperty<bool> _canBuy = new BoolReactiveProperty();

        private readonly HeroInfo _heroInfo;
        private readonly HeroBuyer _heroBuyer;
        private readonly CompositeDisposable _compositeDisposable = new();

        public IReadOnlyReactiveProperty<long> Money;

        public void Buy()
        {
            if (CanBuy.Value)
            {
                
            }
        }
    }
}