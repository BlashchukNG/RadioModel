using Code.Infrastructure.AssetManagement;
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
        public BaseControlPanel CreateBulldozerControlPanel(Transform root) => _assets.Instantiate<BaseControlPanel>(AssetsPath.CONTROL_BULLDOZER, root);

        public void CleanUp()
        {
        }
    }
}