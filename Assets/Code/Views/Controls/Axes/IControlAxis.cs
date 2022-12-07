using System;

namespace Code.Views.Controls.Axes
{
    public interface IControlAxis
    {
        event Action<float> onAxisValueChanged;
    }
}