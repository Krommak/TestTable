namespace Game.Input
{
    public class KeyboardInput : IInputService
    {
        void IInputService.WaitInput(Action<int> action)
        {
            string input = Console.ReadLine();
            int cleanNum = 0;
            while (!int.TryParse(input, out cleanNum)
                || cleanNum <= 0)
            {
                Console.Write($"Значение {input} некорректное, введите правильное значение: ");
                input = Console.ReadLine();
            }
            action?.Invoke(cleanNum);
        }
    }
}