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
        BaseControlPanel CreateBulldozerControlPanel(Transform root);
        void CleanUp();
    }
}