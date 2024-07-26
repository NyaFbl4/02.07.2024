using UniRx;
using UnityEngine;

namespace PresentationModel
{
    public sealed class HeroPresenter : IHeroPresenter
    {
        public string Name   { get; }
        public string Description { get; }
        public Sprite Icon   { get; }
        public string CurrentExperience { get; }
        public string PriceGold  { get; }

        private readonly ReactiveProperty<bool> _canBuy = new BoolReactiveProperty();

        private readonly HeroInfo _heroInfo;

        public HeroPresenter(HeroInfo heroInfo)
        {
            _heroInfo = heroInfo;

            Name = _heroInfo.Name;
            Icon = _heroInfo.Icon;
            Description = _heroInfo.Description;
            CurrentExperience = _heroInfo.CurrentExperience.ToString();
            PriceGold = _heroInfo.MoneyPrice.ToString();
        }
    }
}