namespace Code.Logic.Models
{
    public interface IModel
    {
        void AddMoveModule(IModelMove move);
        void AddRotateModule(IModelRotate rotate);
    }
}