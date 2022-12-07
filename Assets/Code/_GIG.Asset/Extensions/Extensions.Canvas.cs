using UnityEngine;

namespace Code._GIG.Asset.Extensions
{
    public static partial class Extensions
    {
        public static void Enable(this Canvas button) => button.enabled = true;
        public static void Disable(this Canvas button) => button.enabled = false;
    }
}