using MelonLoader;
using UnityEngine.SceneManagement;

namespace Davipresence
{
    class DavigoDataGrabber : MelonMod
    {
        /// <summary>
        /// Gets the current scene. 
        /// </summary>
        public static string GetCurrentScene()
        {
            return SceneManager.GetActiveScene().name;
        }

        public static string GetMapAssetKey(string SceneName)
        {
            
        }
    }
}
