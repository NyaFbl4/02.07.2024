using System;
using Zenject;

namespace PresentationModel
{
    public class MoneyObserver : IInitializable, IDisposable
    {
        private readonly CurrencyView _view;
        private readonly MoneyStorage _storage;

        public MoneyObserver(MoneyStorage storage, CurrencyView view)
        {
            _storage = storage;
            _view = view;
        }

        public void Initialize()
        {
            _storage.OnMoneyChanged += OnMoneyChanged;
            _view.SetupCurrency(_storage.Money);
        }

        public void Dispose()
        {
            _storage.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(long money)
        {
            _view.UpdateCurrency(money);
        }
    }
}