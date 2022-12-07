using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views.Controls.Axes
{
    public class ControlAxis11 :
        MonoBehaviour,
        IControlAxis
    {
        public event Action<float> onAxisValueChanged;

        [SerializeField] private Slider _slider;

        private void Awake()
        {
            _slider.onValueChanged.AddListener(AxisValueChanged);
        }

        private void AxisValueChanged(float value)
        {
            var result = Mathf.Lerp(-1f, 1f, value);
            onAxisValueChanged?.Invoke(result);
        }
    }
}