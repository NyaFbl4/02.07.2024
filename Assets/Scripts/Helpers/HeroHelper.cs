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
        [SerializeField] private HeroInfoView _heroInfoView;
        [SerializeField] private HeroStatsView _heroStatsView;

        private HeroPresenterFactory _heroPresenterFactory;
        private HeroStatsPresenterFactory _heroStatsPresenterFactory;

        [Inject]
        private void Construct(HeroPresenterFactory heroPresenterFactory, 
                               HeroStatsPresenterFactory heroStatsPresenterFactory)
        {
            _heroStatsPresenterFactory = heroStatsPresenterFactory;
            _heroPresenterFactory = heroPresenterFactory;
        }

        [Button]
        public void PopupHeroShow()
        {
            IHeroStatsPresenter heroStatsPresenter = _heroStatsPresenterFactory.Create(_heroInfo);
            _heroStatsView.ShowPopupStats(heroStatsPresenter);
            IHeroPresenter heroPresenter = _heroPresenterFactory.Create(_heroInfo);
            _heroInfoView.Show(heroPresenter);
        }
        /*
        [Button]
        public void HeroPopupShow()
        {
            IHeroPresenter heroPresenter = _heroPresenterFactory.Create(_heroInfo);
            _heroPopup.Show(heroPresenter);
        }
        */
    }
}