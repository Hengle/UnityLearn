using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
	public class UnloadPrefabExample : MonoBehaviour
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("QFramework/Example/20.UnloadPrefab", false, 20)]
		static void MenuItem()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("UnloadPrefabExample").AddComponent<UnloadPrefabExample>();
		}
#endif
		// Use this for initialization
		IEnumerator Start()
		{
			var homePanel = Resources.Load<GameObject>("HomePanel");
			
			yield return new WaitForSeconds(5.0f);


			homePanel = null;
			
			Resources.UnloadUnusedAssets();
			
			Debug.Log("homepanel unloaded");
			
		}
	}
}