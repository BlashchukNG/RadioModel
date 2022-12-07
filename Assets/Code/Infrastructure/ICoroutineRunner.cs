using System.Collections;
using UnityEngine;

namespace Code.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartEnumerator(IEnumerator coroutine);
        void StopEnumerator(IEnumerator coroutine);
        void StopAllEnumerators();
    }
}