using System.Collections;
using System.Collections.Generic;
using Code.Infrastructure.States;
using Code.Infrastructure.Updater;
using Code.Logic;
using UnityEngine;

namespace Code.Infrastructure
{
    public sealed class GameBootstrapper :
        MonoBehaviour,
        ICoroutineRunner,
        IUpdater
    {
        [SerializeField] private LoadingCurtain _curtain;

        private Game _game;

        private readonly List<IUpdatable> _updatables = new(100);
        private readonly List<ITick> _ticks = new(100);
        private readonly List<IFixedTick> _fixedTicks = new(100);
        private readonly List<ILateTick> _lateTicks = new(5);

        private void Awake()
        {
            _game = new Game(coroutineRunner: this, this, Instantiate(_curtain));
            _game.stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }

        #region ICoroutineRunner

        public Coroutine StartEnumerator(IEnumerator coroutine) => StartCoroutine(coroutine);
        public void StopEnumerator(IEnumerator coroutine) => StopCoroutine(coroutine);
        public void StopAllEnumerators() => StopAllCoroutines();

        #endregion


        #region IUpdater

        public void Add(IUpdatable updatable)
        {
            _updatables.Add(updatable);
            if (updatable is ITick tick) _ticks.Add(tick);
            if (updatable is IFixedTick fixedTick) _fixedTicks.Add(fixedTick);
            if (updatable is ILateTick lateTick) _lateTicks.Add(lateTick);
        }

        public void Remove(IUpdatable updatable)
        {
            _updatables.Remove(updatable);
            if (updatable is ITick tick) _ticks.Add(tick);
            if (updatable is IFixedTick fixedTick) _fixedTicks.Add(fixedTick);
            if (updatable is ILateTick lateTick) _lateTicks.Add(lateTick);
        }

        public void Tick(float delta)
        {
            var count = _ticks.Count;
            for (var i = 0; i < count; i++) _ticks[i].Tick(delta);
        }

        public void FixedTick(float delta)
        {
            var count = _fixedTicks.Count;
            for (var i = 0; i < count; i++) _fixedTicks[i].FixedTick(delta);
        }

        public void LateTick(float delta)
        {
            var count = _lateTicks.Count;
            for (var i = 0; i < count; i++) _lateTicks[i].LateTick(delta);
        }

        #endregion
    }
}