using Code.Infrastructure.Services;
using Code.Logic.Environment;
using Code.Logic.Models;
using Code.Logic.UserCamera;
using Code.Views.Controls.Panels;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory :
        IService
    {
        GameObject CreateViewMain();
        GameObject CreateViewUserData(Transform root);

        CameraFollow CreateCamera();
        
        Ground CreateGround();
        
        
        BaseControlPanel CreateBulldozerControlPanel(Transform root);
        
        
        Model CreateBulldozerModel();
        
        
        void CleanUp();
    }
}