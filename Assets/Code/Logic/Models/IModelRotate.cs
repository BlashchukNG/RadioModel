using UnityEngine;

namespace Code.Logic.Models
{
    public interface IModelRotate
    {
        void Initial(Transform modelTransform);
        void Rotate(float rotation);
    }
}