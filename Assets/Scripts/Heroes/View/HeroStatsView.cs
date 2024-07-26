using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public sealed class HeroStatsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TMP_Text _health;
        [SerializeField] private TMP_Text _attack;
        [SerializeField] private TMP_Text _currentExperience;
        
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private Button _buttonClose;

        private IHeroStatsPresenter _heroStatsPresenter;
        private readonly CompositeDisposable _disposable = new();

        public void ShowPopupStats(IHeroStatsPresenter iHeroStatsPresenter)
        {
            IHeroStatsPresenter heroStatsPresenter = iHeroStatsPresenter as IHeroStatsPresenter;
            gameObject.SetActive(true);

            _heroStatsPresenter = heroStatsPresenter;

            _lvl.text               = heroStatsPresenter.Lvl;
            _health.text            = heroStatsPresenter.Health;
            _attack.text            = heroStatsPresenter.Attack;
            _currentExperience.text = heroStatsPresenter.CurrentExperience;
            
            _buyButton.SetPrice(_heroStatsPresenter.PriceGold);
            
            _heroStatsPresenter.LvlUp.BindTo(_buyButton.Button).AddTo(_disposable);
            _heroStatsPresenter.CanBuy.Subscribe(OnCanBuy).AddTo(_disposable);
            _buttonClose.onClick.AddListener(Hide);
            UpdateButtonState();
        }

        public void UpdateStats(int newLvl, int newHealth, int newAttack)
        {
            _lvl.text    = newLvl.ToString();
            _health.text = newHealth.ToString();
            _attack.text = newAttack.ToString();
        }

        public void ExperienceUpdate(int experienceValue)
        {
            _currentExperience.text = experienceValue.ToString();
        }
        
        private void OnCanBuy(bool _)
        {
            UpdateButtonState();
        }
        
        private void UpdateButtonState()
        {
            var buttonState = _heroStatsPresenter.CanBuy.Value
                ? BuyButtonState.Available
                : BuyButtonState.Locked;
            _buyButton.SetState(buttonState);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            _buyButton.RemoveListener(OnBuyButtoClicked);
            _buttonClose.onClick.RemoveListener(Hide);
            _disposable.Clear();
        }
        
        private void OnBuyButtoClicked()
        {
            if (_heroStatsPresenter.CanBuy.Value)
            {
                _heroStatsPresenter.Buy();
            }
        }
    }
}