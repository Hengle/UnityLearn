using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace QFramework
{
	public class ResLoader
	{
		public static List<Res> SharedLoadedReses = new List<Res>();
		
		
		private List<Res> mResRecord = new List<Res>();


		public T LoadAsset<T>(string assetName) where T : Object
		{
			// 查询当前的 资源记录
			var res = mResRecord.Find(loadedAsset => loadedAsset.Name == assetName);

			if (res != null)
			{
				return res.Asset as T;
			}

			// 查询全局资源池
			res = SharedLoadedReses.Find(loadedAsset => loadedAsset.Name == assetName);

			if (res != null)
			{
				mResRecord.Add(res);
				
				res.Retain();

				return res.Asset as T;
			}


			// 真正加载资源
			var asset = Resources.Load<T>(assetName);

			res = new Res(asset);
			
			res.Retain();

			SharedLoadedReses.Add(res);

			mResRecord.Add(res);

			return asset;
		}


		public void ReleaseAll()
		{
			mResRecord.ForEach(loadedAsset => loadedAsset.Release());

			mResRecord.Clear();
		}
	}
}