using UnityEngine;

namespace Code.Logic.Models
{
    public sealed class ModelMove :
        IModelMove
    {
        private Transform _modelTransform;
        private Rigidbody _motor;

        public void Initial(Transform modelTransform, Rigidbody motor)
        {
            _modelTransform = modelTransform;
            _motor = motor;
        }

        public void Move(float power)
        {
            //_motor.velocity = _modelTransform.transform.forward * power;
            _motor.AddForce(_modelTransform.transform.forward * power, ForceMode.Force);
        }
    }
}