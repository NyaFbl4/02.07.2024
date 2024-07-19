using System;
using UniRx;
using Zenject;

namespace PresentationModel
{
    public sealed class MoneyObserver : IDisposable
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
        }

        private void OnMoneyChanged(long money)
        {
            _view.UpdateCurrency(money);
        }
    }
}