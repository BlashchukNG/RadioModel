using Code.Constants;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Builders;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Services;
using Code.Infrastructure.Services.Control;
using Code.Infrastructure.Services.Settings;

namespace Code.Infrastructure.States
{
    public sealed class BootstrapState :
        IState
    {
        private const string Initial = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _services;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, ServiceLocator services, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            _coroutineRunner = coroutineRunner;
            RegisterServices();
        }

        public void Enter()
        {
            EnterLoadScene();
        }

        public void Exit()
        {
        }

        private void EnterLoadScene()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(SceneNames.GAME);
        }

        private void RegisterServices()
        {
            var settings = _services.RegisterSingle<ISettingsService>(new SettingsService());
            var assets = _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            var gameFactory = _services.RegisterSingle<IGameFactory>(new GameFactory(assets));
            var modelBuilder = _services.RegisterSingle<IModelBuilder>(new ModelBuilder(gameFactory));
            var controls = _services.RegisterSingle<IControlService>(new ControlService(settings));
        }
    }
}