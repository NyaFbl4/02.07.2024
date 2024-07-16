using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public sealed class HeroPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TMP_Text _health;
        [SerializeField] private TMP_Text _attack;

        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private Button _buttonClose;
    }
}