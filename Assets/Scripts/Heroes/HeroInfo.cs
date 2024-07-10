using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PresentationModel
{
    [CreateAssetMenu(fileName = "Hero", menuName = "Hero/New Hero")]
    public sealed class HeroInfo : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _lvl;
        [SerializeField] private int _health;
        [SerializeField] private int _attack;

        [Space]
        [SerializeField] private int _moneyPrice;
        [SerializeField] private int _gemPrice;
    }
}
