using Assets.Scripts.Configs;
using Assets.Scripts.Experience;
using PresentationModel.Presenters;
using UniRx;
using UnityEngine;
using Zenject;

namespace PresentationModel 
{
    public class HeroController
    {
        private ExperienceManager _experienceManager;
        
        private Hero _hero;
        private HeroStatsView _heroStatsView;
        //private HeroStatsPresenterFactory _heroStatsPresenterFactory;

        private int _increaseHealth;
        private int _increaseAttack;

        public HeroController(Hero hero, HeroStatsView heroStatsView) 
            //HeroStatsPresenterFactory heroStatsPresenterFactory)
        {
            _hero = hero;
            _heroStatsView = heroStatsView;
            //_heroStatsPresenterFactory = heroStatsPresenterFactory;
        }

        public void LvlUp()
        {
            _hero.Lvl++;
            _hero.Health += _increaseHealth;
            _hero.Attack += _increaseAttack;
            _heroStatsView.UpdateStats(_hero.Lvl, _hero.Health, _hero.Attack);
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

            //IHeroStatsPresenter heroStatsPresenter = _heroStatsPresenterFactory.Create();

            //ShowStats(_hero);
        }

        private void ShowStats(Hero hero)
        {
            
        }
    }
}