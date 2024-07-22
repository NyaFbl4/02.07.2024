using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LevelUpConfig", menuName = "Configs/LevelUpConfig")]
    public class LevelUpConfig : ScriptableObject
    {
        [SerializeField] private int _healthUp;
        [SerializeField] private int _attackUp;
        
        public int HealthUp => _healthUp;
        public int AttackUp => _attackUp;
    }
}