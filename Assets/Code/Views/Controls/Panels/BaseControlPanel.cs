using Code.Enums;
using Code.Views.Controls.Axes;
using UnityEngine;

namespace Code.Views.Controls.Panels
{
    public abstract class BaseControlPanel :
        MonoBehaviour
    {
        public ControlAxis01 Power => _axisPower;
        public ControlAxis11 Acceleration => _axisAcceleration;
        public ControlAxis11 Direction => _axisDirection;

        public ModelType type;

        [SerializeField] private ControlAxis01 _axisPower;
        [SerializeField] private ControlAxis11 _axisAcceleration;
        [SerializeField] private ControlAxis11 _axisDirection;
    }
}