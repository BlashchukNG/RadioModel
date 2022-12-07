namespace Code.Infrastructure.Updater
{
    public interface IUpdater
    {
        void Add(IUpdatable updatable);
        void Remove(IUpdatable updatable);
        void Tick(float delta);
        void FixedTick(float delta);
        void LateTick(float delta);
    }
}