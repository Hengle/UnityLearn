using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace WFrameWork
{
    public class ActivitySimplify
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/06.GameObject active简化")]
#endif
        private static void MenuClicked()
        {
            var gameObject = new GameObject();
            Hide(gameObject);
            Show(gameObject);
        }

        public static void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}