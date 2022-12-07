namespace Code.Infrastructure.Updater
{
    public interface ILateTick
    {
        void LateTick(float delta);
    }
}