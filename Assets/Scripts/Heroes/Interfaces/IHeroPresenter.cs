using UnityEngine;
using UniRx;

namespace PresentationModel
{
    public interface IHeroPresenter
    {
        string Name   { get; }
        public string Description { get; }
        Sprite Icon  { get; }

        

        IReadOnlyReactiveProperty<bool> CanBuy { get; }
        ReactiveCommand BuyCommand { get; }
        
        void Buy();
    }
}