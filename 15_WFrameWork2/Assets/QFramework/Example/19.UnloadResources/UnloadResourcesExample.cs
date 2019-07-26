using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
	public class UnloadResourcesExample : MonoBehaviour
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("QFramework/Example/19.UnloadResources", false, 19)]
		static void MenuItem()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("UnloadResourcesExample").AddComponent<UnloadResourcesExample>();
		}
#endif
	
		
		
		// Use this for initialization
		IEnumerator Start()
		{
			var audioClip = Resources.Load<AudioClip>("coin");
			
			yield return new WaitForSeconds(5.0f);
			
			Resources.UnloadAsset(audioClip);
			
			Debug.Log("coin unloaded");
		}
	}
}