using Code.Infrastructure.Services;
using Code.Views.Controls.Panels;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory :
        IService
    {
        GameObject CreateViewMain();
        GameObject CreateViewUserData(Transform root);
        void CleanUp();
        BaseControlPanel CreateBulldozerControlPanel(Transform root);
    }
}