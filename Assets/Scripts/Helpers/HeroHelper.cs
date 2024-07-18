using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public class HeroHelper : MonoBehaviour
    {
        [SerializeField] private HeroInfo _heroInfo;
        [SerializeField] private HeroPopup _heroPopup;

        private HeroPresenterFactory _heroPresenterFactory;

        [Inject]
        private void Construct(HeroPresenterFactory heroPresenterFactory)
        {
            _heroPresenterFactory = heroPresenterFactory;
        }
            
        [Button]
        public void HeroPopupShow()
        {
            IHeroPresenter heroPresenter = _heroPresenterFactory.Create(_heroInfo);
            _heroPopup.Show(heroPresenter);
        }
        
    }
}