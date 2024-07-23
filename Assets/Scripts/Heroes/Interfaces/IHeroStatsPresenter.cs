﻿using UnityEngine;
using UniRx;

namespace PresentationModel
{
    public interface IHeroStatsPresenter
    {
        string Lvl    { get; }
        
        string Health { get; }
        
        string Attack { get; }
        
        string PriceGold  { get; }

        ReactiveCommand LvlUp { get; }
        
        IReadOnlyReactiveProperty<bool> CanBuy { get; }

        void Buy();
    }
}