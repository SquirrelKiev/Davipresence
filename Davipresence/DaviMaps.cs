namespace Davipresence
{
    /// <summary>
    /// An object that represents a map. 
    /// </summary>
    public class DaviMap
     {
        public string MapID, AssetKey, DisplayName;

        public DaviMap(string DaviMapID, string DaviAssetKey, string DaviDisplayName)
        {
            this.MapID = DaviMapID;
            this.AssetKey = DaviAssetKey;
            this.DisplayName = DaviDisplayName;
        }
    }
}
