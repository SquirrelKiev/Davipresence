using MelonLoader;
using System;
using Newtonsoft.Json;

namespace Davipresence
{
    class DavimapsImport
    {

        public static Davimap[] Davimaps = new Davimap[2] {
            new Davimap( "Map_Kairos", "Kairos", "map_kairos" ),
            new Davimap( "HellsGate", "Hell's Gate", "hellsgate")
        };

        

        public static Davimap GetDavimap(string sceneName, string mapID)
        {
            foreach (Davimap davimap in Davimaps)
            {
                if(DP.currentSceneName == davimap.mapID)
                {
                    return davimap;
                }
            }

            MelonLogger.Warning("Map lacking support! Please message SquirrelKiev#0002 with the map link and this ID: " + mapID);
            return new Davimap(sceneName, "unknown", sceneName);
        }

        private static void GetLatestMapInfo()
        {
        }
    }
}
