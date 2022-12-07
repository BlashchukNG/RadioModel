using UnityEngine;

namespace Code.Logic.Models
{
    public sealed class ModelRotate :
        IModelRotate
    {
        private Rigidbody _body;

        public void Initial(Rigidbody body)
        {
            _body = body;
        }

        public void Rotate(float rotation)
        {
            _body.transform.Rotate(Vector3.up, rotation);
        }
    }
}