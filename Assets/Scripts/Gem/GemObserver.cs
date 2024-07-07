using System;
using Zenject;

namespace MVP
{
    public class GemObserver : IInitializable, IDisposable
    {
        private readonly CurrencyView _view;
        private readonly GemStorage _storage;

        public GemObserver(GemStorage storage, CurrencyView view)
        {
            _storage = storage;
            _view = view;
        }

        public void Initialize()
        {
            _storage.OnGemChanged += OnMoneyChanged;
            _view.SetupCurrency(_storage.Gem);
        }

        public void Dispose()
        {
            _storage.OnGemChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(long money)
        {
            _view.UpdateCurrency(money);
        }
    }
}