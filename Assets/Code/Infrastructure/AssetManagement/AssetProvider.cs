using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
    public sealed class AssetProvider :
        IAssetProvider
    {
        public GameObject Instantiate(string path) => Object.Instantiate(Resources.Load<GameObject>(path));
        public GameObject Instantiate(string path, Transform root) => Object.Instantiate(Resources.Load<GameObject>(path), root);

        public T Instantiate<T>(string path, Transform root)
            where T : MonoBehaviour =>
            Object.Instantiate(Resources.Load<T>(path), root);

        public T Instantiate<T>(string path)
            where T : MonoBehaviour =>
            Object.Instantiate(Resources.Load<T>(path));
    }
}