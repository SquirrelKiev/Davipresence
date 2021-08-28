using MelonLoader;
using Newtonsoft.Json;
using System.Net;

namespace Davipresence
{
    class DavimapsImport
    {

        public static Davimap[] Davimaps;

        public static Davimap[] GetDaviMaps()
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://raw.githubusercontent.com/SquirrelKiev/Davipresence/prototypes/davimaps.json");
            client.Dispose();

            Davimap[] davimaps = JsonConvert.DeserializeObject<Davimap[]>(json);
            return davimaps;
        }

        public static Davimap GetDavimap(string sceneName, string mapID)
        {
            foreach (Davimap davimap in Davimaps)
            {
                if (DP.matchController.match.Map.identifier == davimap.mapID)
                {
                    return davimap;
                }
            }

            MelonLogger.Warning("Map lacking support! Please message SquirrelKiev#0002 with the map link and this ID: " + mapID);
            return new Davimap(sceneName, sceneName, "unknown");
        }

    }
}
