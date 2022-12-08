using Code.Views.Controls.Panels;
using UnityEngine;

namespace Code.Logic.Models
{
    public sealed class Model :
        MonoBehaviour,
        IModel
    {
        [SerializeField] private Rigidbody _body;
        [SerializeField] private Rigidbody _motor;

        [SerializeField] private float _power;
        [SerializeField] private float _rotationSpeed;

        private BaseControlPanel _panel;
        private IModelMove _move;
        private IModelRotate _rotate;

        private float _currentPower;
        private float _currentAccelerate;
        private float _currentRotation;

        public IModel Initial(BaseControlPanel panel)
        {
            panel.Power.onAxisValueChanged += PowerValueChanged;
            panel.Acceleration.onAxisValueChanged += AccelerationValueChanged;
            panel.Direction.onAxisValueChanged += DirectionValueChanged;

            _panel = panel;

            _motor.transform.parent = null;

            return this;
        }

        private void PowerValueChanged(float value) => _currentPower = value;

        private void AccelerationValueChanged(float value) =>
            _currentAccelerate = value switch
            {
                < -0.1f => -1,
                > 0.1f  => 1,
                _       => 0
            };

        private void DirectionValueChanged(float value)
        {
            if (value is < -0.1f or > 0.1f) _currentRotation = value;
            else _currentRotation = 0;
        }

        public void AddMoveModule(IModelMove move)
        {
            move.Initial(transform, _motor);
            _move = move;
        }

        public void AddRotateModule(IModelRotate rotate)
        {
            rotate.Initial(_body, _motor);
            _rotate = rotate;
        }

        public Transform GetCameraTarget() => _motor.transform;

        public void FixedTick(float delta)
        {
            _move.Move(_currentPower * _power * _currentAccelerate);
        }

        public void Tick(float delta)
        {
            _body.position = _motor.transform.position;
            _rotate.Rotate(_rotationSpeed * _currentRotation * delta);
        }
    }
}