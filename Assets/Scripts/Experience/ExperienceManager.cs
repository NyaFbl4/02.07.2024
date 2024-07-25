using PresentationModel;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Experience
{
    public sealed class ExperienceManager
    {
        public ReactiveProperty<int> PropertyExperience = new ReactiveProperty<int>();
        public HeroController _HeroController;

        public ExperienceManager(HeroController heroController)
        {
            _HeroController = heroController;
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
                PropertyExperience.Value = 0;
                _HeroController.LvlUp();
                Debug.Log("получен уровень");
            }
            
        }
    }
}