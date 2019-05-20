using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

namespace WFrameWork
{
    public class TransformIdendity
    {
        [MenuItem("WFrameWork/9.Transform重置")]
        private static void MenuClicked()
        {
            var gameObject = new GameObject();
            TransformLocalPositionSimplify.SetLocalPosX(gameObject.transform, 20);
            Identity(gameObject.transform);
        }

        public static void Identity(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
        }
    }
}