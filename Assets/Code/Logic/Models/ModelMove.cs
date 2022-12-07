using UnityEngine;

namespace Code.Logic.Models
{
    public sealed class ModelMove :
        IModelMove
    {
        private Rigidbody _body;

        public void Initial(Rigidbody body)
        {
            _body = body;
        }

        public void Move(float power)
        {
            _body.velocity = _body.transform.forward * power;
        }
    }
}