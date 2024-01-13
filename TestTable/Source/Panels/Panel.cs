using Game.Input;
using Game.Items;

namespace Game.Panels
{
    public class Panel
    {
        protected IInputService InputService;
        protected List<Item> Items;
        protected PanelType PanelType;
        protected string Label;
        protected Action<Item> OnChooseAction;

        public virtual Panel Init(PanelType type, IInputService inputService)
        {
            PanelType = type;
            Items = new List<Item>(); 
            InputService = inputService;

            return this;
        }

        public Panel SetOnChooseAction(Action<Item> action)
        {
            OnChooseAction = action;

            return this;
        }

        public void ShowPanel()
        {
            ShowItems();

            if(Items.Count > 0)
                Console.WriteLine("Введите номер предмета который хотите взять");
            else
                Console.WriteLine("На столе ничего нет");

            InputService.WaitInput((index) => GetItem(index));
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        private void GetItem(int index)
        {
            OnChooseAction(Items[index]);

            if (index < Items.Count)
            {
                Items.RemoveBySwap(index);
            }
            Console.Clear();
            ShowPanel();
        }

        private void ShowItems()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i}. {Items[i].Name}");
            }
        }
    }
}