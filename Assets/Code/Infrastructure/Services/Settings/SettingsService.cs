using Code.Configs;
using UnityEngine;

namespace Code.Infrastructure.Services.Settings
{
    public sealed class SettingsService :
        ISettingsService
    {
        private const string CONFIGS = "Configs/config main";

        public SettingsService() => MainConfig = Resources.Load<MainConfig>(CONFIGS);

        public MainConfig MainConfig { get; }
    }
}