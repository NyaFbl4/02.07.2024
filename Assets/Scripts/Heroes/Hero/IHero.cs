using UnityEngine;

namespace PresentationModel
{
    public interface IHero
    {
        string Name   { get; }
        Sprite Icon   { get; }
        string Description { get; }
        string Lvl    { get; }
        string Health { get; }
        string Attack { get; }
        public string CurrentExperience { get; }
    }
}