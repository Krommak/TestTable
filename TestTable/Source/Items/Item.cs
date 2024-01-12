namespace Game.Items
{
    public class Item
    {
        protected string ItemName;

        public Item(string localizationKey)
        {
            ItemName = localizationKey;
        }

        public virtual string Name => ItemName;
    }
}