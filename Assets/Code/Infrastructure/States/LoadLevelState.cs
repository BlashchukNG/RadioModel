using Code.Curtain;
using Code.Enums;
using Code.Infrastructure.Builders;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Updater;
using Code.Views.Controls.Panels;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public sealed class LoadLevelState :
        IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        private readonly IUpdater _updater;
        private readonly IGameFactory _gameFactory;
        private readonly IModelBuilder _modelBuilder;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUpdater updater, LoadingCurtain loadingCurtain, IGameFactory gameFactory,
            IModelBuilder modelBuilder)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _updater = updater;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _modelBuilder = modelBuilder;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.CleanUp();

            _sceneLoader.Load(sceneName, onLoaded: OnLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            InitGame();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGame()
        {
            var ground = _gameFactory.CreateGround();

            var panel = Object.FindObjectOfType<BulldozerControlPanel>();
            var model = _modelBuilder.Build(ModelType.Bulldozer)
                                     .WithMoveModule()
                                     .WithRotateModule()
                                     .GetModel()
                                     .Initial(panel);

            var camera = _gameFactory.CreateCamera()
                                     .Initialize(model.GetCameraTarget());
            
            _updater.Add(model);
            _updater.Add(camera);
        }
    }
}