using System.Collections;
using System.Collections.Generic;
using PresentationModel.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public sealed class HeroHelper : MonoBehaviour
    {
        [SerializeField] private HeroInfo _heroInfo;
        //[SerializeField] private HeroPopup _heroPopup;
        [SerializeField] private PopupHero _popupHero;

        private HeroPresenterFactory _heroPresenterFactory;
        private HeroStatsPresenterFactory _heroStatsPresenterFactory;

        [Inject]
        private void Construct(HeroPresenterFactory heroPresenterFactory)
        {
            _heroPresenterFactory = heroPresenterFactory;
        }
            
        [Button]
        public void HeroPopupShow()
        {
            //IHeroPresenter heroPresenter = _heroPresenterFactory.Create(_heroInfo);
            IHeroStatsPresenter heroStatsPresenter = _heroStatsPresenterFactory.Create(_heroInfo);        
            //_heroPopup.Show(heroPresenter, heroStatsPresenter);
            _popupHero.ShowPopupStats(heroStatsPresenter);
        }
        
    }
}