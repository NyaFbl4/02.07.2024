using Assets.Scripts.Experience;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PresentationModel
{
    public sealed class ProgressBarController : MonoBehaviour
    {
        [SerializeField] private Image _progressBarNotCompleted;

        [SerializeField] private int _value;
        [SerializeField] private int _maxValue;
        [SerializeField] private bool _isCorrectlyConfigured;

        private ExperienceManager _experienceManager;
        private readonly CompositeDisposable _compositeDisposable = new();

        [Inject]
        public void Construct(ExperienceManager experienceManager)
        {
            _experienceManager = experienceManager;
        }
        
        private void Start()
        {
            _experienceManager.PropertyExperience.Subscribe(newExperienceValue =>
            {
                _value = newExperienceValue;
                UpdateProgressBar();
            }).AddTo(_compositeDisposable);
            
            if (_progressBarNotCompleted.type == Image.Type.Filled & 
                _progressBarNotCompleted.fillMethod == Image.FillMethod.Horizontal)
            {
                _isCorrectlyConfigured = true;

                _value = _experienceManager.PropertyExperience.Value;
                _maxValue = 100;
                
                UpdateProgressBar();
            }
            else
            {
                Debug.Log("{GameLog} => [ProgressBarController]");
            }
        }

        private void UpdateProgressBar()
        {
            if (!_isCorrectlyConfigured)
            {
                return;
            }

            _progressBarNotCompleted.fillAmount = (float) _value / _maxValue;
        }

        [Button]
        public void AddValue(int value)
        {
            _value += value;
            UpdateProgressBar();
        }
    }
}