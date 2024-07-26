using UnityEngine;

namespace PresentationModel
{
    public interface IHeroPresenter
    {
        string Name   { get; }
        public string Description { get; }
        Sprite Icon  { get; }
    }
}