using Code.Infrastructure.Factory;
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

        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
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
            Debug.Log("Scene Loaded");

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