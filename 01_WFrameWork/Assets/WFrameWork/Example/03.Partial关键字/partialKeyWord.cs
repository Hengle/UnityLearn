using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFrameWork
{
    public partial class GameObjectSimplify
    {
        public static void Show(Transform transform)
        {
            transform.gameObject.SetActive(true);
        }

        public static void Hide(Transform transform)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public partial class TransformSimplify
    {
        public static void AddChild(Transform parentTrams, Transform childTrans)
        {
            childTrans.SetParent(parentTrams);
        }
    }

    public class partialKeyWord
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFrameWork/03.partial关键字" , false, 3)]
#endif
        private static void MenuClicked()
        {
            var parentTrans = new GameObject("ParentTransform").transform;
            var childTrans = new GameObject("ChildTransform").transform;
            TransformSimplify.AddChild(parentTrans, childTrans);
            GameObjectSimplify.Hide(parentTrans);
        }
    }
}