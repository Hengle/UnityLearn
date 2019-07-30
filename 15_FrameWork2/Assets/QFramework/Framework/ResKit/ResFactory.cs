namespace QFramework
{
    public class ResFactory
    {
        public static Res Create(string assetName, string assetBundleName)
        {
            Res res = null;
            
            if (assetBundleName != null)
            {
                res = new AssetRes(assetName, assetBundleName);
            }
            else if (assetName.StartsWith("resources://"))
            {
                res = new ResourcesRes(assetName);
            }
            else
            {
                res = new AssetBundleRes(assetName);
            }

            return res;
        }
    }
}