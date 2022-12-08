using Code.Infrastructure.Updater;
using Code.Views.Controls.Panels;
using UnityEngine;

namespace Code.Logic.Models
{
    public interface IModel :
        IUpdatable,
        ITick,
        IFixedTick
    {
        IModel Initial(BaseControlPanel panel);
        void AddMoveModule(IModelMove move);
        void AddRotateModule(IModelRotate rotate);
        Transform GetCameraTarget();
    }
}