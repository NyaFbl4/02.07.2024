using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public sealed class HeroPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TMP_Text _health;
        [SerializeField] private TMP_Text _attack;
        [SerializeField] private Image _icon;

        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private Button _buttonClose;

        private IHeroPresenter _heroPresenter;
        private readonly CompositeDisposable _disposable = new();

        public void Show(IHeroPresenter iHeroPresenter, IHeroStatsPresenter iHeroStatsPresenter)
        {
            IHeroPresenter heroPresenter = iHeroPresenter as IHeroPresenter;
            IHeroStatsPresenter heroStatsPresenter = iHeroStatsPresenter as IHeroStatsPresenter;
            gameObject.SetActive(true);

            _heroPresenter = heroPresenter;
            _name.text     = heroPresenter.Name;
            _lvl.text      = heroStatsPresenter.Lvl;
            _health.text   = heroStatsPresenter.Health;
            _attack.text   = heroStatsPresenter.Attack;
            _icon.sprite   = heroPresenter.Icon;
            
            _buyButton.SetPrice(_heroPresenter.PriceGold);

            _heroPresenter.BuyCommand.BindTo(_buyButton.Button).AddTo(_disposable);
            _heroPresenter.CanBuy.Subscribe(OnCanBuy).AddTo(_disposable);
            _buttonClose.onClick.AddListener(Hide);
            UpdateButtonState();
        }

        private void OnCanBuy(bool _)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            var buttonState = _heroPresenter.CanBuy.Value
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
            if (_heroPresenter.CanBuy.Value)
            {
                _heroPresenter.Buy();;
            }
        }
    }
}