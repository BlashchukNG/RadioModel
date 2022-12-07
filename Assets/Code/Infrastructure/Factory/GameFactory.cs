using Code.Constants;
using Code.Infrastructure.AssetManagement;
using Code.Logic.Environment;
using Code.Logic.Models;
using Code.Views.Controls.Panels;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public sealed class GameFactory :
        IGameFactory
    {
        private readonly IAssetProvider _assets;


        public GameFactory(IAssetProvider assets) => _assets = assets;

        public GameObject CreateViewMain() => _assets.Instantiate(AssetsPath.VIEW_MAIN);
        public GameObject CreateViewUserData(Transform root) => _assets.Instantiate(AssetsPath.VIEW_USER_DATA, root);

        #region Environment

        public Ground CreateGround() => _assets.Instantiate<Ground>(AssetsPath.ENV_GROUND);
        
        #endregion

        #region Controls

        public BaseControlPanel CreateBulldozerControlPanel(Transform root) => _assets.Instantiate<BaseControlPanel>(AssetsPath.CONTROL_BULLDOZER, root);

        #endregion


        #region Models

        public Model CreateBulldozerModel() => _assets.Instantiate<Model>(AssetsPath.MODEL_BULLDOZER);

        #endregion


        public void CleanUp()
        {
        }
    }
}