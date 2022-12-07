using Code.Curtain;
using Code.Infrastructure.Services;
using Code.Infrastructure.States;
using Code.Infrastructure.Updater;

namespace Code.Infrastructure
{
    public sealed class Game
    {
        public readonly GameStateMachine stateMachine;

        public Game(ICoroutineRunner coroutineRunner, IUpdater updater, LoadingCurtain loadingCurtain)
        {
            stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), updater, loadingCurtain, ServiceLocator.Container, coroutineRunner);
        }
    }
}