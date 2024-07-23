using UnityEngine;

namespace PresentationModel
{
    public class Hero
    {
        private string _name;
        private Sprite _icon;
        private string _description;
        private int _lvl;
        private int _health;
        private int _attack;
        private int _currentExperience;

        public Hero(HeroInfo heroInfo)
        {
            _name              = heroInfo.Name;
            _icon              = heroInfo.Icon;
            _description       = heroInfo.Description;
            _lvl               = heroInfo.Lvl;
            _health            = heroInfo.Health;
            _attack            = heroInfo.Attack;
            _currentExperience = heroInfo.CurrentExperience;
        }
    }
}