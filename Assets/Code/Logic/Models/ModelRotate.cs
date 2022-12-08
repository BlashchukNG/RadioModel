using UnityEngine;

namespace Code.Logic.Models
{
    public sealed class ModelRotate :
        IModelRotate
    {
        private Transform _modelTransform;

        public void Initial(Transform modelTransform) => _modelTransform = modelTransform;

        public void Rotate(float rotation) =>
            _modelTransform.rotation = Quaternion.Euler(_modelTransform.rotation.eulerAngles +
                                                        new Vector3(0f, rotation, 0f));
    }
}