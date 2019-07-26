using UnityEngine;

namespace QFramework
{
	public class UIXXXPanel : MonoBehaviour
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("QFramework/Example/21.UIXXXPanel", false, 21)]
		static void MenuItem()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("UIXXXPanel")
				.AddComponent<UIXXXPanel>()
				.gameObject.AddComponent<UIYYYPanel>();
		}
#endif

		ResLoader mResLoader = new ResLoader();

		private void Start()
		{
			var coinClip = mResLoader.LoadAsset<AudioClip>("coin");

			var homeClip = mResLoader.LoadAsset<AudioClip>("home");

			var bgClip = mResLoader.LoadAsset<AudioClip>("coin");
			///

			OtherFunction();
		}


		private void OtherFunction()
		{
			var bgClip = mResLoader.LoadAsset<AudioClip>("coin");
		}

		private void OnDestroy()
		{
			mResLoader.ReleaseAll();
		}
	}

	public class UIYYYPanel : MonoBehaviour
	{
		ResLoader mResLoader = new ResLoader();

		private void Start()
		{
			var coinClip = mResLoader.LoadAsset<AudioClip>("coin");

			var homeClip = mResLoader.LoadAsset<AudioClip>("home");

			var bgClip = mResLoader.LoadAsset<AudioClip>("coin");
			///

			OtherFunction();
		}


		private void OtherFunction()
		{
			var bgClip = mResLoader.LoadAsset<AudioClip>("coin");
		}

		private void OnDestroy()
		{
			mResLoader.ReleaseAll();
		}
	}
}