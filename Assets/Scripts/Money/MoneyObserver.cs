using System;
using UniRx;
using Zenject;

namespace PresentationModel
{
    public class MoneyObserver : IDisposable
    {
        private readonly CurrencyView _view;
        private readonly MoneyStorage _storage;
        private readonly IDisposable _disposable;

        public MoneyObserver(MoneyStorage storage, CurrencyView view)
        {
            _storage = storage;
            _view = view;
            _disposable = _storage.Money.SkipLatestValueOnSubscribe().Subscribe(OnMoneyChanged);
        }

        public void Dispose()
        {
            _disposable.Dispose();
            //_storage.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(long money)
        {
            _view.UpdateCurrency(money);
        }
    }
}