using UnityEngine;

namespace MVP
{
    public class CurrencyViewProvider : MonoBehaviour
    {
        [SerializeField] private CurrencyView _gemView;
        [SerializeField] private CurrencyView _moneyView;

        public CurrencyView GemView => _gemView;
        public CurrencyView MoneyView => _moneyView;
    }
}