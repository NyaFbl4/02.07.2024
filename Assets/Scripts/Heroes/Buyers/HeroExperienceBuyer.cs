﻿using UnityEngine;

namespace PresentationModel
{
    public sealed class HeroExperienceBuyer
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly ExperienceManager _experienceManager;
        private int quantityExperience = 10;

        public HeroExperienceBuyer(MoneyStorage moneyStorage, 
                                   ExperienceManager experienceManager)
        {
            _moneyStorage = moneyStorage;
            _experienceManager = experienceManager;
        }

        public void BuyExperience(HeroInfo heroInfo)
        {
            if (CanBuy(heroInfo))
            {
                _moneyStorage.SpendMoney(heroInfo.MoneyPrice);
                _experienceManager.AddExperience(quantityExperience);
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