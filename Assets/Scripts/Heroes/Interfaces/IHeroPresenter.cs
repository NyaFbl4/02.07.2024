﻿using UnityEngine;
using UniRx;

namespace PresentationModel
{
    public interface IHeroPresenter
    {
        string Name   { get; }
        
        /*
        string Lvl    { get; }
        string Health { get; }
        string Attack { get; }
        */
        public string Description { get; }
        public string CurrentExperience { get; }
        Sprite Icon  { get; }
        string PriceGold { get; }
        

        IReadOnlyReactiveProperty<bool> CanBuy { get; }
        ReactiveCommand BuyCommand { get; }
        
        void Buy();
    }
}