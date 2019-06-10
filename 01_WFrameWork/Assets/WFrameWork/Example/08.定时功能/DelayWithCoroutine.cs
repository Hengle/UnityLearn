using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class DelayWithCoroutine : MonoBehaviourSimplify
    {
        protected override void OnBeforeDestroy()
        {
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/8.定时功能", false, 8)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject().AddComponent<DelayWithCoroutine>();
        }
#endif

        void Start()
        {
            Delay(5.0f, () =>
            {
                Debug.Log("5s之后");
                this.Hide();
            });
        }
    }
}