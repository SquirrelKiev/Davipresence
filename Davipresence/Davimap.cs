namespace Davipresence
{
    class Davimap
    {
        public string mapID, assetKey, displayName;

        public Davimap(string mapID, string displayName, string assetKey)
        {
            this.mapID = mapID;
            this.displayName = displayName;
            this.assetKey = assetKey;
        }
    }
}
