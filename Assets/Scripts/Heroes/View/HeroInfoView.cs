using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public sealed class HeroInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _description;

        private IHeroPresenter _heroPresenter;
        private IHeroStatsPresenter _heroStatsPresenter;

        public void Show(IHeroPresenter iHeroPresenter)
        {
            IHeroPresenter heroPresenter = iHeroPresenter as IHeroPresenter;
            gameObject.SetActive(true);

            _heroPresenter    = heroPresenter;

            _name.text        = heroPresenter.Name;
            _description.text = heroPresenter.Description;
            _icon.sprite      = heroPresenter.Icon;
        }
    }
}