using System;

namespace PresentationModel
{
    public sealed class GemStorage
    {
        public event Action<long> OnGemChanged;

        public long Gem { get; private set; }

        public GemStorage(long gem)
        {
            Gem = gem; 
        }

        public void AddGem(long gem)
        {
            Gem += gem;
            OnGemChanged?.Invoke(Gem);
        }

        public void SpendGem(long gem)
        {
            long gemTemp = Gem - gem;
            if (gemTemp < 0)
            {
                throw new InvalidOperationException($"");
            }
            Gem -= gem;
            OnGemChanged?.Invoke(Gem);
        }
    }
}