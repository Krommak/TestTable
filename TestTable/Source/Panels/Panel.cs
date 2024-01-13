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

        public Panel(IInputService inputService)
        {
            Items = new List<Item>();
            InputService = inputService;
        }

        public virtual Panel Init(PanelType type)
        {
            PanelType = type;

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

        private void GetItem(int num)
        {
            int index = num - 1;

            if (index < Items.Count)
            {
                OnChooseAction(Items[index]);

                Items.RemoveBySwap(index);
            }
            Console.Clear();
            ShowPanel();
        }

        private void ShowItems()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i+1}. {Items[i].Name}");
            }
        }
    }
}