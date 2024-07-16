using UnityEngine;
using UniRx;

namespace PresentationModel
{
    public interface IHeroPresenter
    {
        string Title { get; }
        string Description { get; }
        Sprite Icon { get; }
        string Price { get; }
        
        IReadOnlyReactiveProperty<bool> CanBuy { get; }
        ReactiveCommand BuyCommand { get; }
        
        void Buy();
    }
}