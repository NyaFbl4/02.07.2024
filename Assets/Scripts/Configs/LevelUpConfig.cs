using UnityEngine;

namespace PresentationModel
{
    [CreateAssetMenu(fileName = "LevelUpConfig", menuName = "Configs/LevelUpConfig")]
    public sealed class LevelUpConfig : ScriptableObject
    {
        [SerializeField] private int _healthUp;
        [SerializeField] private int _attackUp;
        
        public int HealthUp => _healthUp;
        public int AttackUp => _attackUp;
    }
}