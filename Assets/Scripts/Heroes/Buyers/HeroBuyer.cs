﻿using UnityEngine;

namespace PresentationModel
{
    public sealed class HeroBuyer
    {
        private readonly MoneyStorage _moneyStorage;

        public HeroBuyer(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        public void Buy(HeroInfo heroInfo)
        {
            if (CanBuy(heroInfo))
            {
                _moneyStorage.SpendMoney(heroInfo.MoneyPrice);
                Debug.Log($"<color=green>Hero {heroInfo.Name} successfully purchased!</color>");
            }
            else
            {
                Debug.LogWarning($"<color=red>Not enough money for hero {heroInfo.Name}!</color>");
            }
        }

        public bool CanBuy(HeroInfo heroInfo)
        {
            return _moneyStorage.Money.Value >= heroInfo.MoneyPrice;
        }
    }
}