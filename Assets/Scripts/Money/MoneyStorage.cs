using System;
using UniRx;


namespace PresentationModel
{
    public class MoneyStorage
    {
        //public event Action<long> OnMoneyChanged;

        public IReadOnlyReactiveProperty<long> Money => _money;

        private readonly ReactiveProperty<long> _money;
        
        //public long Money { get; private set; }

        public MoneyStorage(long money)
        {
            //Money = money;
            _money = new LongReactiveProperty(money);
        }

        public void AddMoney(long money)
        {
            //Money += money;
            //OnMoneyChanged?.Invoke(Money);
            _money.Value += money;
        }

        public void SpendMoney(long money)
        {
            /*
            long moneyTemp = Money - money;
            if (moneyTemp < 0)
            {
                throw new InvalidOperationException($"");
            }
            Money -= money;
            OnMoneyChanged?.Invoke(Money);
            */
            
            _money.SetValueAndForceNotify(_money.Value - money);
        }
    }
}