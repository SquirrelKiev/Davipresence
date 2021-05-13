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
            daviMaps.Add(new DaviMap("25145379-29aa-4ea4-8c2c-ffe2d49c6438", "melonrun", "Melon Run"));
            daviMaps.Add(new DaviMap("a112c0fe-2085-4632-9ef5-57ed8165c669", "davihome05", "DaviHouse 0.5"));
            daviMaps.Add(new DaviMap("3a37af3d-c2d8-41df-9d08-d8ccc5caaef6", "davihome05", "DaviHouse V1"));
            daviMaps.Add(new DaviMap("6005bc61-53ba-4dac-9800-fbb2155cbbf8", "caldera", "Caldera"));
            daviMaps.Add(new DaviMap("b5463a50-7141-456b-82c2-67a65b87e507", "castleisland", "Battle For Castle Island"));
            daviMaps.Add(new DaviMap("d13f4ccb-5418-4403-8ddc-908bc713db06", "provingplayground", "Proving Playground"));
            daviMaps.Add(new DaviMap("42270802-d28c-4bf1-a5f1-55b716ea8be3", "davihands", "DaviHands"));

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
                if(daviMap.MapID == Presence.currentMapID)
                {
                    return daviMap;
                }
            }
            MelonLogger.Msg("Map lacking support! Please message SquirrelKiev#0002 with the map name and this UUID: " + Presence.currentMapID);
            return new DaviMap(Presence.currentMapID, "unknown", sceneName);
        }
    }
}