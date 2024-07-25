using Assets.Scripts.Configs;
using Assets.Scripts.Experience;
using UniRx;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public class HeroController
    {
        //private LevelUpConfig _levelUpConfig;

        
        private Hero _hero;
        private HeroStatsView _heroStatsView;

        private int _increaseHealth;
        private int _increaseAttack;

        public HeroController(Hero hero, HeroStatsView heroStatsView)
        {
            _hero = hero;
            _heroStatsView = heroStatsView;
        }

        public void LvlUp()
        {
            _heroStatsView.UpdateStats();
        }

        public void CreateHero(HeroInfo heroInfo, LevelUpConfig levelUpConfig)
        {
            _increaseHealth = levelUpConfig.HealthUp;
            _increaseAttack = levelUpConfig.AttackUp;
            
            _hero = new Hero();
            
            _hero.Name = heroInfo.Name;
            _hero.Icon = heroInfo.Icon;
            _hero.Description = heroInfo.Description;
            _hero.Lvl = heroInfo.Lvl;
            _hero.Health = heroInfo.Health;
            _hero.Attack = heroInfo.Attack;
            _hero.CurrentExperience = heroInfo.CurrentExperience;
            Debug.Log("герой создан");
            ShowStats(_hero);
        }

        private void ShowStats(Hero hero)
        {
            Debug.Log(_increaseHealth.ToString());
            Debug.Log(_increaseAttack.ToString());
        }
    }
}