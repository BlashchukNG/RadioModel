using Code.Enums;
using Code.Infrastructure.Services;
using Code.Logic.Models;

namespace Code.Infrastructure.Builders
{
    public interface IModelBuilder :
        IService
    {
        IModelBuilder Build(ModelType type);
        IModelBuilder WithMoveModule();
        IModelBuilder WithRotateModule();
        IModel GetModel();
    }
}