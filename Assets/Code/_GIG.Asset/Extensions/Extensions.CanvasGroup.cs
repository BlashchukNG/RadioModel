using System.Collections;
using UnityEngine;

namespace Code._GIG.Asset.Extensions
{
    public static partial class Extensions
    {
        public static IEnumerator DOShow(this CanvasGroup group)
        {
            group.GetComponent<Canvas>().enabled = true;

            while (group.alpha < 1)
            {
                group.alpha += 0.03f;
                yield return new WaitForSeconds(0.005f);
            }
        }

        public static IEnumerator DOHide(this CanvasGroup group)
        {
            while (group.alpha > 0)
            {
                group.alpha -= 0.03f;
                yield return new WaitForSeconds(0.005f);
            }

            group.GetComponent<Canvas>().enabled = false;
        }
    }
}