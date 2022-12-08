using UnityEngine;

namespace Code.Logic.Models
{
    public sealed class ModelRotate :
        IModelRotate
    {
        private Transform _modelTransform;
        private Rigidbody _body;
        private Rigidbody _motor;

        public void Initial(Rigidbody body, Rigidbody motor)
        {
            _motor = motor;
            _body = body;
        }

        public void Rotate(float rotation)
        {
            _body.transform.Rotate(_body.transform.up, rotation);
        }
    }
}