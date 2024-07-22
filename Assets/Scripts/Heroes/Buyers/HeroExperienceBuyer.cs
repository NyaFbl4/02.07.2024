using UnityEngine;

namespace PresentationModel
{
    public sealed class HeroExperienceBuyer
    {
        private readonly MoneyStorage _moneyStorage;

        public HeroExperienceBuyer(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        public void BuyExperience(HeroInfo heroInfo)
        {
            if (CanBuy(heroInfo))
            {
                _moneyStorage.SpendMoney(heroInfo.MoneyPrice);
                Debug.Log($"<color=green>Hero {heroInfo.Name} gained experience!</color>");
            }
            else
            {
                Debug.LogWarning($"<color=red>Not enough money to buy experience {heroInfo.Name}!</color>");
            }
        }

        public bool CanBuy(HeroInfo heroInfo)
        {
            return _moneyStorage.Money.Value >= heroInfo.MoneyPrice;
        }
    }
}