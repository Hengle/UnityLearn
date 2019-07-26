using UnityEngine;

namespace QFramework
{
    public class Res : SimpleRC
    {
        public Object Asset { get; private set; }

        public string Name
        {
            get { return Asset.name; }
        }

        public Res(Object asset)
        {
            Asset = asset;
        }

        protected override void OnZeroRef()
        {
            Resources.UnloadAsset(Asset);

            ResLoader.SharedLoadedReses.Remove(this);
                
            Asset = null;
        }
    }
}