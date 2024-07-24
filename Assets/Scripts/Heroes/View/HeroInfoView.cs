﻿using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public sealed class HeroInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _description;

        //[SerializeField] private BuyButton _buyButton;
        //[SerializeField] private Button _buttonClose;

        private IHeroPresenter _heroPresenter;
        private IHeroStatsPresenter _heroStatsPresenter;
        private readonly CompositeDisposable _disposable = new();

        public void Show(IHeroPresenter iHeroPresenter)
        {
            IHeroPresenter heroPresenter = iHeroPresenter as IHeroPresenter;
            //IHeroStatsPresenter heroStatsPresenter = iHeroStatsPresenter as IHeroStatsPresenter;
            gameObject.SetActive(true);

            _heroPresenter = heroPresenter;
            //_heroStatsPresenter = heroStatsPresenter;
                
            _name.text     = heroPresenter.Name;
            _description.text = heroPresenter.Description;
            //_lvl.text      = heroStatsPresenter.Lvl;
            //_health.text   = heroStatsPresenter.Health;
            //_attack.text   = heroStatsPresenter.Attack;
            _icon.sprite   = heroPresenter.Icon;
            
            /*
            _buyButton.SetPrice(_heroPresenter.PriceGold);

            _heroPresenter.BuyCommand.BindTo(_buyButton.Button).AddTo(_disposable);
            _heroPresenter.CanBuy.Subscribe(OnCanBuy).AddTo(_disposable);
            _buttonClose.onClick.AddListener(Hide);
            UpdateButtonState();
            */
        }

        private void OnCanBuy(bool _)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            /*
             var buttonState = _heroStatsPresenter.CanBuy.Value
                ? BuyButtonState.Available
                : BuyButtonState.Locked;
            _buyButton.SetState(buttonState);
            */
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            //_buyButton.RemoveListener(OnBuyButtoClicked);
            //_buttonClose.onClick.RemoveListener(Hide);
            _disposable.Clear();
        }
        
        private void OnBuyButtoClicked()
        {
            /*
            if (_heroStatsPresenter.CanBuy.Value)
            {
                _heroStatsPresenter.Buy();;
            }
            */
        }
    }
}