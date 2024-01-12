namespace Game.Items
{
    public class MultipleItem : Item
    {
        private int _count { get; set; }

        public MultipleItem(string localizationKey, int count) : base(localizationKey)
        {
            _count = count;
        }

        public override string Name => $"{_count} {ItemName.MultipleLocalizeText(_count)}";
    }
}
