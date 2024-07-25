using Assets.Scripts.Experience;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
        private ExperienceManager _experienceManager;
        private readonly CompositeDisposable _disposable = new();

        public void Start()
        {
            _experienceManager.PropertyExperience.Subscribe(newExperienceValue =>
            {
                ExperienceUpdate(newExperienceValue);
            }).AddTo(_disposable);
        }

        [Inject]
        public void Construct(ExperienceManager experienceManager)
        {
            _experienceManager = experienceManager;
        }
        
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

        public void UpdateStats()
        {
            _lvl.text    = 10.ToString();
            _health.text = 10.ToString();
            _attack.text = 10.ToString();
        }
        
        
        private void ExperienceUpdate(int experienceValue)
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