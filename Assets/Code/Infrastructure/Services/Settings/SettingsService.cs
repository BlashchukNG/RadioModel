using Code.Configs;
using Code.Constants;
using UnityEngine;

namespace Code.Infrastructure.Services.Settings
{
    public sealed class SettingsService :
        ISettingsService
    {
        public SettingsService()
        {
            MainConfig = Resources.Load<MainConfig>(ConfigsPath.MAIN);
            ControlsConfig = Resources.Load<ControlsConfig>(ConfigsPath.MAIN);
        }

        public MainConfig MainConfig { get; }
        public ControlsConfig ControlsConfig { get; }
    }
}