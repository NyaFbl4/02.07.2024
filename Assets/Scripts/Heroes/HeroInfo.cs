using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PresentationModel
{
    [CreateAssetMenu(fileName = "Hero", menuName = "Hero/New Hero")]
    public sealed class HeroInfo : ScriptableObject
    {
        [SerializeField] private string _name; //Большая вьюха, большой презентер
        [SerializeField] private Sprite _icon; //Большая вьюха, большой презентер
        [SerializeField] [TextArea(3, 5)] private string _description; //Большая вьюха, большой презентер
        
        [SerializeField] private int _lvl;
        [SerializeField] private int _health;
        [SerializeField] private int _attack;
        [SerializeField] private int _currentExperience;
        
        [SerializeField] private int _moneyPrice;

        public string Name => _name;
        public Sprite Icon => _icon;
        public string Description => _description;
        public int Lvl => _lvl;
        public int Health => _health;
        public int Attack => _attack;
        public int CurrentExperience => _currentExperience;
        public int MoneyPrice => _moneyPrice;

        public void LvlUp(int value)
        {
            _lvl += value;
        }
        public void UpdateHealth(int value)
        {
            _health += value;
        }
        public void AttackHealth(int value)
        {
            _attack += value;
        }
    }
}
