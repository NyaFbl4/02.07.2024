using UnityEngine;

namespace PresentationModel
{
    public class HeroController
    {
        //private HeroInfo _heroInfo;
        private Hero _hero;

        public HeroController(Hero hero)
        {
            _hero = hero;
        }
        
        public void CreateHero(HeroInfo heroInfo)
        {
            _hero = new Hero(heroInfo);
            ShowStats(_hero);
        }

        private void ShowStats(Hero hero)
        {
            Debug.Log(hero.Name);
            //Debug.Log(hero.Name.ToString());
            Debug.Log(hero.Description);
            Debug.Log(hero.Lvl.ToString());
            Debug.Log(hero.Health.ToString());
            Debug.Log(hero.Attack.ToString());
            Debug.Log(hero.CurrentExperience.ToString());
        }
    }
}