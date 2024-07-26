using PresentationModel.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public sealed class HeroHelper : MonoBehaviour
    {
        [SerializeField] private HeroInfo _heroInfo;
        [SerializeField] private LevelUpConfig _levelUpConfig;
        
        [SerializeField] private HeroInfoView _heroInfoView;
        [SerializeField] private HeroStatsView _heroStatsView;

        private HeroPresenterFactory _heroPresenterFactory;
        private HeroStatsPresenterFactory _heroStatsPresenterFactory;
        private HeroController _heroController;

        [Inject]
        private void Construct(HeroPresenterFactory heroPresenterFactory, 
                               HeroStatsPresenterFactory heroStatsPresenterFactory,
                               HeroController heroController)
        {
            _heroStatsPresenterFactory = heroStatsPresenterFactory;
            _heroPresenterFactory = heroPresenterFactory;
            _heroController = heroController;
        }

        [Button]
        public void PopupHeroShow()
        {
            _heroController.CreateHero(_heroInfo, _levelUpConfig);
            IHeroStatsPresenter heroStatsPresenter = _heroStatsPresenterFactory.Create(_heroInfo);
            _heroStatsView.ShowPopupStats(heroStatsPresenter);
            IHeroPresenter heroPresenter = _heroPresenterFactory.Create(_heroInfo);
            _heroInfoView.Show(heroPresenter);
        }
    }
}