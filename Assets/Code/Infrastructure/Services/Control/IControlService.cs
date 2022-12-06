using Code.Enums;
using Code.Views.Controls.Panels;

namespace Code.Infrastructure.Services.Control
{
    public interface IControlService :
        IService
    {
        BaseControlPanel ControlPanel { get; }
        void ChangeControlPanel(ModelType type);
        void AddControlPanel(BaseControlPanel panel);
    }
}