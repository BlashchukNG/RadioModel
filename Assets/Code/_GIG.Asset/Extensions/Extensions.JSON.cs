using UnityEngine;

namespace Code._GIG.Asset.Extensions
{
    public static partial class Extensions
    {
        public static string TOJson<T>(this T obj) => JsonUtility.ToJson(obj, true);
        public static T FromJson<T>(this string str) => JsonUtility.FromJson<T>(str);
    }
}