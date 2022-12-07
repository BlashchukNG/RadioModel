using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views.Controls.Axes
{
    public class ControlAxis01 :
        MonoBehaviour,
        IControlAxis
    {
        public event Action<float> onAxisValueChanged;

        [SerializeField] private Slider _slider;

        private void Awake()
        {
            _slider.onValueChanged.AddListener(AxisValueChanged);
        }

        private void AxisValueChanged(float value) => onAxisValueChanged?.Invoke(value);
    }
}