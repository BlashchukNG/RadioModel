using System;
using System.Collections.Generic;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Services;
using Code.Infrastructure.Updater;
using Code.Logic;

namespace Code.Infrastructure.States
{
    public sealed class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, IUpdater updater, LoadingCurtain loadingCurtain, ServiceLocator services, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services, coroutineRunner),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, updater, loadingCurtain, services.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>()
            where TState : class, IState =>
            ChangeState<TState>().Enter();

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadedState<TPayload> =>
            ChangeState<TState>().Enter(payload);

        private TState ChangeState<TState>()
            where TState : class, IExitableState
        {
            _activeState?.Exit();

            var state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>()
            where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}