namespace Code.Infrastructure.Updater
{
    public interface IUpdater
    {
        void Add(IUpdatable updatable);
        void Remove(IUpdatable updatable);
    }
}