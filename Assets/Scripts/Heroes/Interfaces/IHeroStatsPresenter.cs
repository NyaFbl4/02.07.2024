using UnityEngine;
using UniRx;

namespace PresentationModel
{
    public class IHeroStatsPresenter
    {
        string Lvl    { get; }
        
        string Health { get; }
        
        string Attack { get; }

        ReactiveCommand LvlUp { get; }
    }
}