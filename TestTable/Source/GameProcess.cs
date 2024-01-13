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

            var inputService = new KeyboardInput();

            var table = new Panel();

            _panels.Add(PanelType.Inventory, new Panel());
            _panels.Add(PanelType.Table, table);

            table
                .Init(PanelType.Table, inputService)
                .SetOnChooseAction((item) => AddItemToInventory(item))
                .ShowPanel();

            foreach (var panel in _panels)
            {
                if(_staticData.TryGetItems(panel.Key, out var items))
                {
                    foreach (var item in items)
                    {
                        panel.Value.AddItem(item);
                    }
                }
            }
        }

        private void AddItemToInventory(Item item)
        {
            _panels[PanelType.Inventory].AddItem(item);
        }
    }
}