using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public class Hero
    {
        public string Name { get; set; }
        public Sprite Icon { get; set; }
        public string Description { get; set; } 
        public int Lvl { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int CurrentExperience { get; set; }
        
        //private readonly HeroInfo _heroInfo;


        
        /*
        public string Name => _name;
        public Sprite Icon => _icon;
        public string Description => _description;
        public int Lvl => _lvl;
        public int Health => _health;
        public int Attack => _attack;
        public int CurrentExperience => _currentExperience;
        //public int MoneyPrice => _moneyPrice;
        */
    }
}