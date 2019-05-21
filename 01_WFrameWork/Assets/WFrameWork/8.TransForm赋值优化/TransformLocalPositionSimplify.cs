#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WFrameWork
{
    public class TransformLocalPositionSimplify
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/08.Transform位置简化")]
#endif
        static void MenuClicked()
        {
            GameObject gameObject = new GameObject();
            SetLocalPosX(gameObject.transform, 5.0f);
        }

        public static void SetLocalPosX(Transform transform, float x)
        {
            var localposition = transform.localPosition;
            localposition.x = x;
            transform.localPosition = localposition;
        }
    }
}