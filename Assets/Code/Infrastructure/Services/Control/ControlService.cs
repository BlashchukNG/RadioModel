using System.Collections.Generic;
using Code.Configs;
using Code.Enums;
using Code.Infrastructure.Services.Settings;
using Code.Views.Controls.Panels;

namespace Code.Infrastructure.Services.Control
{
    public sealed class ControlService :
        IControlService
    {
        public BaseControlPanel ControlPanel { get; private set; }

        private readonly ControlsConfig _config;
        private readonly Dictionary<ModelType, BaseControlPanel> _controlPanels;

        public ControlService(ISettingsService settings)
        {
            _config = settings.ControlsConfig;
            _controlPanels = new(10);
        }

        public void ChangeControlPanel(ModelType type) => ControlPanel = _controlPanels[type];
        public void AddControlPanel(BaseControlPanel panel) => _controlPanels[panel.type] = panel;
    }
}