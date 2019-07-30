using UnityEngine;

namespace QFramework
{
	public class NewBehaviourScript : MonoBehaviour
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("QFramework/Playground")]
		private static void Test()
		{
		}

		public void Playmode()
		{
			Debug.Log(HotUpdateMgr.Instance.GetLocalResVersion());
		}
#endif
	}
}