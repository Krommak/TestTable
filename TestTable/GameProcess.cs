using Game.Input;
using Game.Panels;

namespace Game
{
    public class GameProcess
    {
        private StaticData _staticData;
        private Panel _table;
        private IInputService _inputService;

        public void Start()
        {
            _staticData = new StaticData();
            _staticData.Fill();

            _inputService = new KeyboardInput();

            _table = new Panel();

            _table.Init(PanelType.Table, _inputService)
                    .SetItems(_staticData)
                    .CreateActions()
                    .ShowPanel();
        }
    }
}