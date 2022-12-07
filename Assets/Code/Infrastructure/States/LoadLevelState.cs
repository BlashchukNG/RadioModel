using Code.Infrastructure.Factory;
using Code.Infrastructure.Updater;
using Code.Logic;
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

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUpdater updater, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _updater = updater;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
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
            // var main = _gameFactory.CreateViewMain().GetComponent<MainView>();
            // main.Initialize(_data.userData);
        }
    }
}