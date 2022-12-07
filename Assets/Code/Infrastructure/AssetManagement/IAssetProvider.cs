using Code.Infrastructure.Services;
using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
    public interface IAssetProvider :
        IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Transform root);
        T Instantiate<T>(string path, Transform root)
            where T : MonoBehaviour;
    }
}