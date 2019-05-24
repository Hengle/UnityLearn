using System;
using System.Collections;
using UnityEngine;

namespace WFrameWork
{
    public partial class MonoBehaviourSimplify
    {
        public void Delay(float seconds, Action onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds, onFinished));
        }

        private static IEnumerator DelayCoroutine(float seconds, Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            onFinished();
        }
    }

    public class DelayWithCoroutine : MonoBehaviourSimplify
    {
        private void Start()
        {
            Debug.Log("start");
            Delay(5.0f, () => { Debug.Log("5 s 之后"); });
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFrameWork/06.定时功能")]
        private static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject().AddComponent<DelayWithCoroutine>();
        }
#endif
    }
}