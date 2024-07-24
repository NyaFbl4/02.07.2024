using UniRx;
using UnityEngine;

namespace Assets.Scripts.Experience
{
    public sealed class ExperienceManager
    {
        public ReactiveProperty<int> PropertyExperience = new ReactiveProperty<int>();

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
                Debug.Log("получен уровень");
            }
        }
    }
}