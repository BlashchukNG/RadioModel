using Code.Infrastructure.Updater;
using UnityEngine;

namespace Code.Logic.UserCamera
{
    public class CameraFollow :
        MonoBehaviour,
        IUpdatable,
        ILateTick
    {
        [SerializeField] private float smooth;

        private Transform _target;

        public CameraFollow Initialize(Transform target)
        {
            _target = target;
            return this;
        }

        public void LateTick(float delta) => 
            transform.position = Vector3.Lerp(transform.position, _target.position, delta * smooth);
    }
}