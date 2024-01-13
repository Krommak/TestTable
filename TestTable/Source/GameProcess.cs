using Game.Input;
using Game.Items;
using Game.Panels;

namespace Game
{
    public class GameProcess
    {
        private Dictionary<PanelType, Panel> _panels;

        private StaticData _staticData;

        public void Start()
        {
            _staticData = new StaticData();
            _staticData.Fill();
            _panels = new Dictionary<PanelType, Panel>();
            var inputService = new KeyboardInput();

            var table = new Panel(inputService);

            _panels.Add(PanelType.Inventory, new Panel(inputService));
            _panels.Add(PanelType.Table, table);

            foreach (var panel in _panels)
            {
                if (_staticData.TryGetItems(panel.Key, out var items))
                {
                    foreach (var item in items)
                    {
                        panel.Value.AddItem(item);
                    }
                }
            }

            table
                .Init(PanelType.Table)
                .SetOnChooseAction((item) => AddItemToInventory(item))
                .ShowPanel();
        }

        private void AddItemToInventory(Item item)
        {
            _panels[PanelType.Inventory].AddItem(item);
        }
    }
}