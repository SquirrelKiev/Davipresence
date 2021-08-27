using System;

namespace Davipresence
{
    class Davimap
    {
        public string mapID, assetKey, displayName;

        public Davimap(string mapID, string assetKey, string displayName)
        {
            this.mapID = mapID;
            this.assetKey = assetKey;
            this.displayName = displayName;
        }
    }
}
