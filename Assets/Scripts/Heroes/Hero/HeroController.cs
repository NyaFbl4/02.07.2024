namespace PresentationModel 
{
    public sealed class HeroController
    { 
        private ExperienceManager _experienceManager;
        private HeroStats _hero;
        private HeroStatsView _heroStatsView;

        private int _increaseHealth;
        private int _increaseAttack;

        public HeroController(HeroStats hero, HeroStatsView heroStatsView)
        {
            _hero = hero;
            _heroStatsView = heroStatsView;
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
            
            _hero = new HeroStats();
            
            _hero.Lvl = heroInfo.Lvl;
            _hero.Health = heroInfo.Health;
            _hero.Attack = heroInfo.Attack;
        }
    }
}