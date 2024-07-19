using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PresentationModel
{
    public sealed class BuyButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _buttonBackground;
        
        [SerializeField] private Sprite _availableButtonSprite;
        [SerializeField] private Sprite _lockedButtonSprite;

        [SerializeField] private BuyButtonState _buttonState;
        
        [SerializeField] private TMP_Text _priceText;

        private Image _priceIcon;
        public Button Button => _button;
        
        
        public void RemoveListener(UnityAction action)
        {
            Button.onClick.RemoveListener(action);
        }
        
        public void SetPrice(string price)
        {
            _priceText.text = price;
        }
        
        public void SetState(BuyButtonState state)
        {
            _buttonState = state;

            switch (state)
            {
                case BuyButtonState.Available:
                    Button.interactable = true;
                    _buttonBackground.sprite = _availableButtonSprite;
                    break;
                
                case BuyButtonState.Locked:
                    Button.interactable = false;
                    _buttonBackground.sprite = _lockedButtonSprite;
                    break;
                
                default:
                    throw new Exception($"Undefined button state {state}!");
            }
        }

    }

    public enum BuyButtonState
    {
        None      = 0,
        Available = 1,
        Locked    = 2,
    }
}