using UnityEngine;

namespace Code.Logic.Models
{
    public interface IModelRotate
    {
        void Initial(Rigidbody body);
        void Rotate(float rotation);
    }
}