using UniRx;

namespace PresentationModel
{
    public sealed class ExperienceManager
    {
        public ReactiveProperty<int> PropertyExperience = new ReactiveProperty<int>();
        public HeroController _heroController;
        public HeroStatsView _heroStatsView;

        public ExperienceManager(HeroController heroController, HeroStatsView heroStatsView)
        {
            _heroController = heroController;
            _heroStatsView = heroStatsView;
        }

        public void TakeExpirience(int exp)
        {
            PropertyExperience.Value = exp;
        }
        
        public void AddExperience(int quantity)
        {
            PropertyExperience.Value += quantity;

            if (PropertyExperience.Value >= 100)
            {
                PropertyExperience.Value -= 100;
                _heroController.LvlUp();
            }
            
            _heroStatsView.ExperienceUpdate(PropertyExperience.Value);
        }
    }
}