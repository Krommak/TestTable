using Game.Items;

namespace Game
{
    public class StaticData
    {
        private Dictionary<PanelType, List<Item>> _items { get; set; }

        public StaticData()
        {
            _items = new Dictionary<PanelType, List<Item>>();
        }

        public void Fill()
        {
            var tableList = new List<Item>();

            tableList.Add(new Item("Амулет"));
            tableList.Add(new MultipleItem("Монет", 36));
            tableList.Add(new Item("Книга"));

            _items.Add(PanelType.Table, tableList);

            _items.Add(PanelType.Inventory, new List<Item>());
        }

        public bool TryGetItems(PanelType type, out List<Item> items)
        {
            if (_items.ContainsKey(type))
            {
                items = _items[type];
                return true;
            }

            items = new List<Item>();
            return false;
        }
    }

    public enum PanelType
    {
        Start,
        Table,
        Inventory,
    }
}
