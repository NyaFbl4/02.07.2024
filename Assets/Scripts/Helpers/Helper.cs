using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public sealed class Helper : MonoBehaviour
    {
        [SerializeField] private long _current;
        private MoneyStorage _moneyStorage;
        private GemStorage _gemStorage;
        
        [Inject]
        private void Construct(MoneyStorage moneyStorage, GemStorage gemStorage)
        {
            _gemStorage = gemStorage;
            _moneyStorage = moneyStorage;
        }

        [Button]
        public void AddMoney()
        {
            _moneyStorage.AddMoney(_current);
        }
        [Button]
        public void SpendMoney()
        {
            _moneyStorage.SpendMoney(_current);
        }
        
        [Button]
        public void AddGem()
        {
            _gemStorage.AddGem(_current);
        }
        [Button]
        public void SpendGem()
        {
            _gemStorage.SpendGem(_current);
        }
        
    }
}