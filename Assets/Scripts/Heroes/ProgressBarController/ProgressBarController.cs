using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public sealed class ProgressBarController : MonoBehaviour
    {
        [SerializeField] private Image _progressBarNotCompleted;

        [SerializeField] private int _value;
        [SerializeField] private int _maxValue;
        [SerializeField] private bool _isCorrectlyConfigured;

        private void Start()
        {
            if (_progressBarNotCompleted.type == Image.Type.Filled & 
                _progressBarNotCompleted.fillMethod == Image.FillMethod.Horizontal)
            {
                _isCorrectlyConfigured = true;

                _value = 0;
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