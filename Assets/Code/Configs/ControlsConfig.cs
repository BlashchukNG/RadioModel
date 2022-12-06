using Code.Views.Controls.Panels;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "config controls", menuName = "GAME/Controls Config", order = 0)]
    public class ControlsConfig :
        ScriptableObject
    {
        public BulldozerControlPanel bulldozerControlPanel;
    }
}