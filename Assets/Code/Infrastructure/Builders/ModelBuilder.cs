using Code.Enums;
using Code.Infrastructure.Factory;
using Code.Logic.Models;

namespace Code.Infrastructure.Builders
{
    public sealed class ModelBuilder :
        IModelBuilder
    {
        private readonly IGameFactory _factory;

        private IModel _construct;

        public ModelBuilder(IGameFactory factory)
        {
            _factory = factory;
        }

        public IModelBuilder Build(ModelType type)
        {
            _construct = type switch
            {
                ModelType.Bulldozer => _factory.CreateBulldozerModel()
            };

            return this;
        }

        public IModelBuilder WithMoveModule()
        {
            _construct.AddMoveModule(new ModelMove());

            return this;
        }

        public IModelBuilder WithRotateModule()
        {
            _construct.AddRotateModule(new ModelRotate());

            return this;
        }

        public IModel GetModel() => _construct;
    }
}