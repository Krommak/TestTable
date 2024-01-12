namespace Game.Input
{
    public interface IInputService
    {
        public abstract void WaitInput(Action<int> action);
    }
}