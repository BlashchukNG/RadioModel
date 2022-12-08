using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace _GAME.AutoIncBuildVer.Editor
{
    public class AutoIncrementBuildVersion : MonoBehaviour
    {
        [PostProcessBuild(0)]
        public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
        {
            //NOTE: Script expects X.X to be your bundleVersion ALREADY.
            //In order for this to work, set your current version number and build number for Android and iOS to
            //your next version (e.g. 1.204)

            string currentVersion = PlayerSettings.bundleVersion;

            try
            {
                int major = Convert.ToInt32(currentVersion.Split('.')[0]);  
                int iteration = Convert.ToInt32(currentVersion.Split('.')[1]);
                int build = Convert.ToInt32(currentVersion.Split('.')[2]) + 1;

                string iterationStr = iteration < 10 ? $"0{iteration}" : iteration.ToString();

                PlayerSettings.bundleVersion = major + "." + iterationStr + "." + $"{build:00}";

                if (buildTarget == BuildTarget.iOS)
                {
                    PlayerSettings.iOS.buildNumber = (major * 10 + build).ToString();
                    Debug.Log("Finished with BundleVersionCode " + PlayerSettings.iOS.buildNumber + " and version " + PlayerSettings.bundleVersion);

                }
                else if (buildTarget == BuildTarget.Android)
                {
                    PlayerSettings.Android.bundleVersionCode = iteration * 100 + build;
                    Debug.Log("Finished with BundleVersionCode " + PlayerSettings.Android.bundleVersionCode + " and version " + PlayerSettings.bundleVersion);
                }

            }
            catch (Exception e)
            {
                Debug.LogError(e);
                Debug.LogError("AutoIncrementBuildVersion script failed. " +
                                            "Make sure your current bundle version is in the format X.X.x (e.g. 1.02.100).");
            }
        }
    }
}