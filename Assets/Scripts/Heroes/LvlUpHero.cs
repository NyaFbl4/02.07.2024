namespace PresentationModel
{
    public sealed class LvlUpHero
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly HeroInfo _heroInfo;

        public LvlUpHero(MoneyStorage moneyStorage, HeroInfo heroInfo)
        {
            _moneyStorage = moneyStorage;
            _heroInfo = heroInfo;
        }

        public void ReceivedExperience()
        {
            
        }
        
        public void UpdateStats(HeroInfo heroInfo)
        {
            
        }
    }
}