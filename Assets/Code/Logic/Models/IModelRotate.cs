using UnityEngine;

namespace Code.Logic.Models
{
    public interface IModelRotate
    {
        void Initial(Rigidbody body, Rigidbody motor);
        void Rotate(float rotation);
    }
}