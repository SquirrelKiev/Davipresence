namespace Davipresence
{
    /// <summary>
    /// An object that represents a map. 
    /// </summary>
    public class DaviMap
     {
        public string SceneName, AssetKey, DisplayName;

        public DaviMap(string DaviMapName, string DaviAssetKey, string DaviDisplayName)
        {
            this.SceneName = DaviMapName;
            this.AssetKey = DaviAssetKey;
            this.DisplayName = DaviDisplayName;
        }
    }
}
