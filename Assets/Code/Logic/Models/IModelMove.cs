using UnityEngine;

namespace Code.Logic.Models
{
    public interface IModelMove
    {
        void Initial(Rigidbody body);
        void Move(float power);
    }
}