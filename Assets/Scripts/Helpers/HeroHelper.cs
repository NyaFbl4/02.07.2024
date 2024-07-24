using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Experience;
using PresentationModel.Presenters;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public sealed class HeroHelper : MonoBehaviour
    {
        [SerializeField] private HeroInfo _heroInfo;
        [SerializeField] private HeroInfoView _heroInfoView;
        [SerializeField] private HeroStatsView _heroStatsView;
        private ExperienceManager _experienceManager;

        private HeroPresenterFactory _heroPresenterFactory;
        private HeroStatsPresenterFactory _heroStatsPresenterFactory;
        
        private readonly CompositeDisposable _compositeDisposable = new();

        void Start()
        {
            _experienceManager.PropertyExperience.Subscribe(newExperienceValue =>
            {
                Debug.Log("Опыт изменился: " + newExperienceValue);
            }).AddTo(_compositeDisposable);
        }
        
        [Inject]
        private void Construct(HeroPresenterFactory heroPresenterFactory, 
                               HeroStatsPresenterFactory heroStatsPresenterFactory,
                               ExperienceManager experienceManager)
        {
            _heroStatsPresenterFactory = heroStatsPresenterFactory;
            _heroPresenterFactory = heroPresenterFactory;
            _experienceManager = experienceManager;
        }

        [Button]
        public void PopupHeroShow()
        {
            IHeroStatsPresenter heroStatsPresenter = _heroStatsPresenterFactory.Create(_heroInfo);
            _heroStatsView.ShowPopupStats(heroStatsPresenter);
            IHeroPresenter heroPresenter = _heroPresenterFactory.Create(_heroInfo);
            _heroInfoView.Show(heroPresenter);
        }

    }
}