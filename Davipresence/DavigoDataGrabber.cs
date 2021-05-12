using MelonLoader;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Davipresence
{
    class DavigoDataGrabber : MelonMod
    {
        public static DaviMap[] DaviMaps()
        {
            List<DaviMap> daviMaps = new List<DaviMap>();
            daviMaps.Add(new DaviMap("Acrophobia", "acrophobia", "Acrophobia"));
            daviMaps.Add(new DaviMap("DiscOfDeath", "discofdeath", "Disc Of Death"));
            daviMaps.Add(new DaviMap("Experiment_Hammer", "experiment_hammer", "Experiment_Hammer"));
            daviMaps.Add(new DaviMap("HellsGate", "hellsgate", "Hell's Gate"));
            daviMaps.Add(new DaviMap("Horizon", "horizon", "Horizon"));
            daviMaps.Add(new DaviMap("Map_Kairos", "map_kairos", "Kairos"));
            daviMaps.Add(new DaviMap("Megalophobia", "megalophobia", "Megalophobia"));
            daviMaps.Add(new DaviMap("OvertureOverpass", "overtureoverpass", "Overture Overpass"));
            daviMaps.Add(new DaviMap("PowerupPickup", "poweruppickup", "Powerup Pickup"));
            daviMaps.Add(new DaviMap("ProvingGround", "provingground", "Proving Ground"));
            daviMaps.Add(new DaviMap("Riverguard", "riverguard", "Riverguard"));
            daviMaps.Add(new DaviMap("Showdown", "showdown", "Showdown"));
            daviMaps.Add(new DaviMap("Tutorial", "tutorial", "Tutorial"));
            daviMaps.Add(new DaviMap("ExperimentInputDelay", "unknown", "Experimental_InputDelay"));
            // Custom Maps
            daviMaps.Add(new DaviMap("Melon Run", "melonrun", "Melon Run"));
            daviMaps.Add(new DaviMap("DaviHome0.5", "davihome05", "Davihouse 0.5"));
            daviMaps.Add(new DaviMap("Caldera", "caldera", "Caldera"));
            daviMaps.Add(new DaviMap("Battle For Castle Island", "castleisland", "Battle For Castle Island"));

            return daviMaps.ToArray();
        }

        /// <summary>
        /// Gets the current scene. 
        /// </summary>
        public static string GetCurrentScene()
        {
            return SceneManager.GetActiveScene().name;
        }

        /// <summary>
        /// Checks the scene against the map list and returns the DaviMap object of it. If no map is found, it returns a placeholder version. 
        /// </summary>
        /// <param name="sceneName">The name of the scene</param>
        /// <returns></returns>
        public static DaviMap GetDaviMap(string sceneName)
        {
            DaviMap[] MapArray = DaviMaps();

            foreach (DaviMap daviMap in MapArray)
            {
                if(daviMap.SceneName == sceneName)
                {
                    return daviMap;
                }
            }
            return new DaviMap(sceneName, "unknown", sceneName);
        }
    }
}