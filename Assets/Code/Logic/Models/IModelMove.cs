using UnityEngine;

namespace Code.Logic.Models
{
    public interface IModelMove
    {
        void Initial(Transform modelTransform, Rigidbody motor);
        void Move(float power);
    }
}