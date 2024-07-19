using UnityEngine;

namespace PresentationModel
{
    public sealed class CurrencyViewProvider : MonoBehaviour
    {
        [SerializeField] private CurrencyView _gemView;
        [SerializeField] private CurrencyView _moneyView;

        public CurrencyView GemView => _gemView;
        public CurrencyView MoneyView => _moneyView;
    }
}