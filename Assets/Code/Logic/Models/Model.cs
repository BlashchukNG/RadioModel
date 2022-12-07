using UnityEngine;

namespace Code.Logic.Models
{
    public sealed class Model :
        MonoBehaviour,
        IModel
    {
        [SerializeField] private Rigidbody body;

        private IModelMove _move;
        private IModelRotate _rotate;

        public void AddMoveModule(IModelMove move) => _move = move;
        public void AddRotateModule(IModelRotate rotate) => _rotate = rotate;
    }
}