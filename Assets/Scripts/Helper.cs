using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace MVP
{
    public class Helper : MonoBehaviour
    {
        [SerializeField] private long _current;
        private MoneyStorage _moneyStorage;
        //private GemStorage _gemStorage;
        
        [Inject]
        private void Construct(MoneyStorage moneyStorage)
        {
            //_gemStorage = gemStorage;
            _moneyStorage = moneyStorage;
        }

        [Button]
        public void AddMoney()
        {
            _moneyStorage.AddMoney(_current);
            Debug.Log(_current.ToString());
        }
        [Button]
        public void SpendMoney()
        {
            _moneyStorage.SpendMoney(_current);
            Debug.Log(_current.ToString());
        }
        /*
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
        */
    }
}